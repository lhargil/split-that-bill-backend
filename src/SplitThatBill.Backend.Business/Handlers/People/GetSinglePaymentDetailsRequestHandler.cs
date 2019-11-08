using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class GetSinglePaymentDetailsRequestHandler : IRequestHandler<GetSinglePaymentDetailsRequest, PaymentDetailDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetSinglePaymentDetailsRequestHandler(SplitThatBillContext splitThatBillContext,
            IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<PaymentDetailDto> Handle(GetSinglePaymentDetailsRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PaymentDetails)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist.");
            }

            var paymentDetails = person.PaymentDetails.Find(pd => pd.Id == request.PaymentDetailId);

            if (null == paymentDetails)
            {
                throw new NullReferenceException("The payment details does not exist.");
            }

            return _mapper.Map<PaymentDetailDto>(paymentDetails);
        }
    }
}
