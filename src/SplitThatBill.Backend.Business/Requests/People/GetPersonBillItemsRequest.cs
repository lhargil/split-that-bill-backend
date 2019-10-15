using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class GetPersonBillItemsRequest : IRequest<PersonBillItemsDto>
    {
        public GetPersonBillItemsRequest(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
