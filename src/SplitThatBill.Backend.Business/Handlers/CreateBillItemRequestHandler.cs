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
    public class CreateBillItemRequestHandler : IRequestHandler<CreateBillItemRequest, BillItemDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public CreateBillItemRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<BillItemDto> Handle(CreateBillItemRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills.FindAsync(request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill to which the bill item belongs does not exist.");
            }

            var billItem = _mapper.Map<BillItem>(request.BillItemFormModel);

            bill.AddBillItem(billItem);
            _splitThatBillContext.Entry(bill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _splitThatBillContext.SaveChangesAsync();

            var billItemDto = _mapper.Map<BillItemDto>(billItem);

            return billItemDto;
        }
    }
}
