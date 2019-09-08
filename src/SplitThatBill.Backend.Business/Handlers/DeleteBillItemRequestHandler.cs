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
    public class DeleteBillItemRequestHandler : IRequestHandler<DeleteBillItemRequest, bool>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public DeleteBillItemRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<bool> Handle(DeleteBillItemRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .FirstOrDefaultAsync(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill to which this bill item belongs does not exist.");
            }

            bill.RemoveBillItem(request.BillItemId);

            _splitThatBillContext.Entry(bill).State = EntityState.Modified;

            var result = await _splitThatBillContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
