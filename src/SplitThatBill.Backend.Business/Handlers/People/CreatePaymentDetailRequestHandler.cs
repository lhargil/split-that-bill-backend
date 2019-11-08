using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Core.OwnedEntities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class CreatePaymentDetailRequestHandler : IRequestHandler<CreatePaymentDetailRequest, PaymentDetailDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public CreatePaymentDetailRequestHandler(SplitThatBillContext splitThatBillContext,
            IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<PaymentDetailDto> Handle(CreatePaymentDetailRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People
                .Include(i => i.PaymentDetails)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person)
            {
                throw new NullReferenceException("The person does not exist.");
            }

            var paymentDetail = PaymentDetail.Create(
                request.PersonPaymentDetailsFormModel.PaymentDetail.BankName,
                request.PersonPaymentDetailsFormModel.PaymentDetail.AccountNumber,
                request.PersonPaymentDetailsFormModel.PaymentDetail.AccountName
            );
            person.AddPaymentDetail(paymentDetail);

            await _splitThatBillContext.SaveChangesAsync();

            return _mapper.Map<PaymentDetailDto>(paymentDetail);
        }
    }
}
