using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class GetBillItemsListRequest : IRequest<List<BillItemDto>>
    {
        public GetBillItemsListRequest(int billId)
        {
            BillId = billId;
        }

        public int BillId { get; }
    }
}
