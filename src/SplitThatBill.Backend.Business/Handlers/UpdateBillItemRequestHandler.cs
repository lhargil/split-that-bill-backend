using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class UpdateBillItemRequestHandler : IRequestHandler<UpdateBillItemRequest, bool>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public UpdateBillItemRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBillItemRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .FirstOrDefaultAsync(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill to which this bill item belongs does not exist.");
            }

            var billItem = bill.BillItems.Find(item => item.Id == request.BillItemId);

            if (null == billItem)
            {
                throw new NullReferenceException("The bill item to update does not exist.");
            }

            _mapper.Map(request.BillItemFormModel, billItem);

            _splitThatBillContext.Entry(bill).State = EntityState.Modified;
            var result = await _splitThatBillContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
