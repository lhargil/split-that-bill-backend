using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class UpdateBillRequestHandler : IRequestHandler<UpdateBillRequest, bool>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public UpdateBillRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBillRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills.FindAsync(request.Id);

            if (null == bill)
            {
                throw new NullReferenceException("The bill to be updated does not exist.");
            }

            var billToUpdate = _mapper.Map(request.BillFormModel, bill);
            _splitThatBillContext.Update(billToUpdate);

            return await _splitThatBillContext.SaveChangesAsync() > 0;
        }
    }
}
