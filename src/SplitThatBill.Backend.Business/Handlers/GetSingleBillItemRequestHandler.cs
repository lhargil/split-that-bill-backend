using System;
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
    public class GetSingleBillItemRequestHandler : IRequestHandler<GetSingleBillItemRequest, BillItemDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetSingleBillItemRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<BillItemDto> Handle(GetSingleBillItemRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .FirstOrDefaultAsync(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The requested bill does not exist.");
            }

            var billItem = bill.BillItems.Find(item => item.Id == request.BillItemId);

            if (null == billItem)
            {
                throw new NullReferenceException("The bill item in the requested bill does not exist.");
            }

            return _mapper.Map<BillItemDto>(billItem);
        }
    }
}
