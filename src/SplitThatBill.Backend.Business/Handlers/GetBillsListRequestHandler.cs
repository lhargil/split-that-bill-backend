using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class GetBillsListRequestHandler : IRequestHandler<GetBillsRequest, List<BillDto>>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public GetBillsListRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }
        public Task<List<BillDto>> Handle(GetBillsRequest request, CancellationToken cancellationToken)
        {
            var bills = _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .ToList();

            return Task.FromResult(bills.Select(item => new BillDto(item)).ToList());
        }
    }
}
