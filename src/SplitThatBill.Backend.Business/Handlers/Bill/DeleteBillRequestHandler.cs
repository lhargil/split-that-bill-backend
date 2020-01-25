using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Business.Requests.Bills;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Bills
{
    public class DeleteBillRequestHandler : IRequestHandler<DeleteBillRequest, bool>
    {
        private readonly SplitThatBillContext _splitThatBillContext;

        public DeleteBillRequestHandler(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }

        public async Task<bool> Handle(DeleteBillRequest request, CancellationToken cancellationToken)
        {
            var item = await _splitThatBillContext.Bills.FindAsync(request.Id);

            if (null == item)
            {
                throw new NullReferenceException("The bill to be deleted does not exist.");
            }

            _splitThatBillContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            return await _splitThatBillContext.SaveChangesAsync() > 0;
        }
    }
}
