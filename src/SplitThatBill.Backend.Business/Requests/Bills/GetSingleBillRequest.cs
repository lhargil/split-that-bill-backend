using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Bills
{
    public class GetSingleBillRequest : IRequest<BillDto>
    {
        public GetSingleBillRequest(int billId)
        {
            BillId = billId;
        }

        public int BillId { get; }
    }

    public class GetSingleBillByGuidRequest : IRequest<BillDto>
    {
        public GetSingleBillByGuidRequest(string guid)
        {
            Guid = guid;
        }

        public string Guid { get; }
    }
}
