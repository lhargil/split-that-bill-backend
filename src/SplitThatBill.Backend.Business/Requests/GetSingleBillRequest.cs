using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class GetSingleBillRequest : IRequest<BillDto>
    {
        public GetSingleBillRequest(int billId)
        {
            BillId = billId;
        }

        public int BillId { get; }
    }
}
