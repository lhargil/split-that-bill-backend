using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class UpdateBillItemRequest : IRequest<bool>
    {
        public UpdateBillItemRequest(int billId, int billItemId, BillItemFormModel billItemFormModel)
        {
            BillId = billId;
            BillItemId = billItemId;
            BillItemFormModel = billItemFormModel;
        }

        public int BillId { get; }
        public int BillItemId { get; }
        public BillItemFormModel BillItemFormModel { get; }
    }
}
