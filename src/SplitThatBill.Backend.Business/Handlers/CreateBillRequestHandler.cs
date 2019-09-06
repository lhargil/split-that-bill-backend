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
    public class CreateBillRequestHandler : IRequestHandler<CreateBillRequest, BillDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public CreateBillRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<BillDto> Handle(CreateBillRequest request, CancellationToken cancellationToken)
        {
            var billToCreate = _mapper.Map<Bill>(request.BillFormModel);

            _splitThatBillContext.Add(billToCreate);

            await _splitThatBillContext.SaveChangesAsync();

            return _mapper.Map<BillDto>(billToCreate);
        }
    }
}
