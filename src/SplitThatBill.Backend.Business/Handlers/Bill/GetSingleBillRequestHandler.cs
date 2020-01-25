using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Business.Requests.Bills;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Bills
{
    public class GetSingleBillRequestHandler : IRequestHandler<GetSingleBillRequest, BillDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetSingleBillRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public Task<BillDto> Handle(GetSingleBillRequest request, CancellationToken cancellationToken)
        {
            var bill = _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                .Include(i => i.Participants)
                    .ThenInclude(j => j.Person)
                        .ThenInclude(p => p.PersonBillItems)
                .FirstOrDefault(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill requested was not found.");
            }

            return Task.FromResult(_mapper.Map<BillDto>(bill));
        }
    }
}
