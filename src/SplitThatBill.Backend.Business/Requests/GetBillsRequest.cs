using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class GetBillsRequest : IRequest<List<BillDto>>
    {
        public GetBillsRequest()
        {
        }
    }
}
