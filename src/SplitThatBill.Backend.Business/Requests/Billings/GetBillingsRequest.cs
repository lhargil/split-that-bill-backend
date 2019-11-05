using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Billings
{
    public class GetBillingsRequest : IRequest<BillingDto>
    {
        public GetBillingsRequest(int billId)
        {
            BillId = billId;
        }

        public int BillId { get; }
    }
}
