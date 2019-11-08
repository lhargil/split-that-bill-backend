using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class GetSinglePaymentDetailsRequest : IRequest<PaymentDetailDto>
    {
        public GetSinglePaymentDetailsRequest(int personId, int paymentDetailId)
        {
            PersonId = personId;
            PaymentDetailId = paymentDetailId;
        }

        public int PersonId { get; }
        public int PaymentDetailId { get; }
    }
}
