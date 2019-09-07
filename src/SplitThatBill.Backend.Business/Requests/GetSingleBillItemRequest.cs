using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class GetSingleBillItemRequest : IRequest<BillItemDto>
    {
        public GetSingleBillItemRequest(int billId, int billItemId)
        {
            BillId = billId;
            BillItemId = billItemId;
        }

        public int BillId { get; }
        public int BillItemId { get; }
    }
}
