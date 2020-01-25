using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Business.Requests.Bills;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Bills
{
    public class GetBillsListRequestHandler : IRequestHandler<GetBillsRequest, List<BillDto>>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;
        private readonly IContextData _contextData;

        public GetBillsListRequestHandler(SplitThatBillContext splitThatBillContext,
          IMapper mapper,
          IContextData contextData)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
            _contextData = contextData;
        }
        public Task<List<BillDto>> Handle(GetBillsRequest request, CancellationToken cancellationToken)
        {
            var bills = _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .Include(i => i.Participants)
                    .ThenInclude(i => i.Person)
                .Where(w => w.BillTakerId == _contextData.CurrentUser.Id)
                .ToList();

            return Task.FromResult(bills.Select(item => _mapper.Map<BillDto>(item)).ToList());
        }
    }
}
