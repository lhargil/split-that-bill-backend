using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class CreatePaymentDetailRequest : IRequest<PaymentDetailDto>
    {
        public CreatePaymentDetailRequest(int personId, PersonPaymentDetailsFormModel personPaymentDetailsFormModel)
        {
            PersonId = personId;
            PersonPaymentDetailsFormModel = personPaymentDetailsFormModel;
        }

        public int PersonId { get; }
        public PersonPaymentDetailsFormModel PersonPaymentDetailsFormModel { get; }
    }
}
