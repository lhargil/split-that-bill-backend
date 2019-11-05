using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Billings
{
    public class GetPersonBillingRequest : IRequest<PersonBillItemsDto>
    {
        public GetPersonBillingRequest(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
