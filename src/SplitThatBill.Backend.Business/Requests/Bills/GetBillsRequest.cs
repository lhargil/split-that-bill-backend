using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Bills
{
    public class GetBillsRequest : IRequest<List<BillDto>>
    {
        public GetBillsRequest()
        {
        }
    }
}
