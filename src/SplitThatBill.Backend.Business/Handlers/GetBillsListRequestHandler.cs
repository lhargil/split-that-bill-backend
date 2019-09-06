using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetBillsListRequestHandler(SplitThatBillContext splitThatBillContext,
          IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }
        public Task<List<BillDto>> Handle(GetBillsRequest request, CancellationToken cancellationToken)
        {
            var bills = _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .ToList();

            return Task.FromResult(bills.Select(item => _mapper.Map<BillDto>(item)).ToList());
        }
    }
}
