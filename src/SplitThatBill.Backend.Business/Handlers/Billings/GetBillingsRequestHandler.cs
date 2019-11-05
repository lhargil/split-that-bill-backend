using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Aggregates;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Billings;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.Billings
{
    public class GetBillingsRequestHandler : IRequestHandler<GetBillingsRequest, BillingDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetBillingsRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<BillingDto> Handle(GetBillingsRequest request, CancellationToken cancellationToken)
        {
            var bill = await _splitThatBillContext.Bills
                .Include(i => i.BillItems)
                    .ThenInclude(i => i.PersonBillItems)
                        .ThenInclude(i => i.Person)
                .Include(i => i.Participants)
                    .ThenInclude(i => i.Person)
                .FirstOrDefaultAsync(item => item.Id == request.BillId);

            if (null == bill)
            {
                throw new NullReferenceException("The bill does not exist.");
            }
            var billing = new Billing(bill, _mapper);

            return billing.ToDto();
        }
    }
}