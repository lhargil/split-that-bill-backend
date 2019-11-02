using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Billing
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
