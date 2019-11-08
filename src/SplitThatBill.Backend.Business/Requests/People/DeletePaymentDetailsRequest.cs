using System;
using MediatR;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class DeletePaymentDetailsRequest : IRequest<int>
    {
        public DeletePaymentDetailsRequest(int personId, int paymentDetailsId)
        {
            PersonId = personId;
            PaymentDetailsId = paymentDetailsId;
        }

        public int PersonId { get; }
        public int PaymentDetailsId { get; }
    }
}
