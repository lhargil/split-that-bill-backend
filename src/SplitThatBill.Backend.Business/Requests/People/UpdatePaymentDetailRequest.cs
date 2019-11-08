using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class UpdatePaymentDetailRequest : IRequest<int>
    {
        public UpdatePaymentDetailRequest(int personId, int paymentDetailId, PersonPaymentDetailsFormModel personPaymentDetailFormModel)
        {
            PersonId = personId;
            PaymentDetailId = paymentDetailId;
            PersonPaymentDetailFormModel = personPaymentDetailFormModel;
        }

        public int PersonId { get; }
        public int PaymentDetailId { get; }
        public PersonPaymentDetailsFormModel PersonPaymentDetailFormModel { get; }
    }
}
