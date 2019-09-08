using System;
using MediatR;

namespace SplitThatBill.Backend.Business.Requests
{
    public class DeleteBillItemRequest : IRequest<bool>
    {
        public DeleteBillItemRequest(int billId, int billItemId)
        {
            BillId = billId;
            BillItemId = billItemId;
        }

        public int BillId { get; }
        public int BillItemId { get; }
    }
}
