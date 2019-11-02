using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Billing;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Billing
{
    public class GetPersonBillingRequestHandler : IRequestHandler<GetPersonBillingRequest, PersonBillItemsDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public GetPersonBillingRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<PersonBillItemsDto> Handle(GetPersonBillingRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PersonBillItems)
                    .ThenInclude(ti => ti.BillItem)
                .FirstOrDefaultAsync(w => w.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person is not found.");
            }

            var personBillItems = new PersonBillItemsDto(person);

            return personBillItems;
        }
    }
}
