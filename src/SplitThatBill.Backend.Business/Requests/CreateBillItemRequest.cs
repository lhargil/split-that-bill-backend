using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class CreateBillItemRequest : IRequest<BillItemDto>
    {
        public CreateBillItemRequest(int billId, BillItemFormModel billItemFormModel)
        {
            BillId = billId;
            BillItemFormModel = billItemFormModel;
        }

        public int BillId { get; }
        public BillItemFormModel BillItemFormModel { get; }
    }
}
