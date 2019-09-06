using System;
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
    public class GetSingleBillRequestHandler : IRequestHandler<GetSingleBillRequest, BillDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public GetSingleBillRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public Task<BillDto> Handle(GetSingleBillRequest request, CancellationToken cancellationToken)
        {
            var bill = _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .FirstOrDefault(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill requested was not found.");
            }

            return Task.FromResult<BillDto>(null);
        }
    }
}
