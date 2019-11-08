using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Core.OwnedEntities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class UpdatePaymentDetailRequestHandler : IRequestHandler<UpdatePaymentDetailRequest, int>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public UpdatePaymentDetailRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<int> Handle(UpdatePaymentDetailRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PaymentDetails)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist.");
            }

            person.UpdatePaymentDetail(request.PaymentDetailId, PaymentDetail.Create(
                request.PersonPaymentDetailFormModel.PaymentDetail.BankName,
                request.PersonPaymentDetailFormModel.PaymentDetail.AccountNumber,
                request.PersonPaymentDetailFormModel.PaymentDetail.AccountName
                ));

            return await _splitThatBillContext.SaveChangesAsync();
        }
    }
}
