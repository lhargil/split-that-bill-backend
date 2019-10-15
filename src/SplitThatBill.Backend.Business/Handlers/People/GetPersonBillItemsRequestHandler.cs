using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class GetPersonBillItemsRequestHandler : IRequestHandler<GetPersonBillItemsRequest, PersonBillItemsDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public GetPersonBillItemsRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<PersonBillItemsDto> Handle(GetPersonBillItemsRequest request, CancellationToken cancellationToken)
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
