using System;
using System.Collections.Generic;
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
    public class GetPaymentDetailsRequestHandler : IRequestHandler<GetPaymentDetailsRequest, List<PaymentDetailDto>>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public GetPaymentDetailsRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<List<PaymentDetailDto>> Handle(GetPaymentDetailsRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                    .Include(i => i.PaymentDetails)
                    .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist");
            }

            var personToReturn = _mapper.Map<PersonDto>(person);

            return personToReturn.PaymentDetails;
        }
    }
}
