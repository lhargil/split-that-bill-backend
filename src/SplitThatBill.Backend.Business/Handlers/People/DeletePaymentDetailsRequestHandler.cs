using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class DeletePaymentDetailsRequestHandler : IRequestHandler<DeletePaymentDetailsRequest, int>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public DeletePaymentDetailsRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<int> Handle(DeletePaymentDetailsRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PaymentDetails)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist.");
            }

            person.RemovePaymentDetail(request.PaymentDetailsId);

            _splitThatBillContext.Entry(person).State = EntityState.Modified;

            return await _splitThatBillContext.SaveChangesAsync();
        }
    }
}
