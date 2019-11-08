using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class GetPaymentDetailsRequest : IRequest<List<PaymentDetailDto>>
    {
        public GetPaymentDetailsRequest(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
