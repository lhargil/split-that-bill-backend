using System;
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
    public class GetBillItemsListRequestHandler : IRequestHandler<GetBillItemsListRequest, List<BillItemDto>>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetBillItemsListRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<List<BillItemDto>> Handle(GetBillItemsListRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .FirstOrDefaultAsync(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The specified bill does not exist.");
            }

            var billItems = bill.BillItems.Select(_mapper.Map<BillItemDto>).ToList();

            return billItems;
        }
    }
}
