using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class CreateBillRequest : IRequest<BillDto>
    {
        public CreateBillRequest(BillFormModel billFormModel)
        {
            BillFormModel = billFormModel;
        }

        public BillFormModel BillFormModel { get; }
    }
}
