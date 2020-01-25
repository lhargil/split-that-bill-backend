using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Bills
{
    public class UpdateBillRequest : IRequest<bool>
    {
        public UpdateBillRequest(int id, BillFormModel billFormModel)
        {
            Id = id;
            BillFormModel = billFormModel;
        }

        public int Id { get; }
        public BillFormModel BillFormModel { get; }
    }
}
