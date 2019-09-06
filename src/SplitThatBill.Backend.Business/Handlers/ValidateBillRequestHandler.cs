using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;

namespace SplitThatBill.Backend.Business.Handlers
{
    public class ValidateBillRequestHandler : IRequestHandler<ValidateBillRequest, ValidationResult>
    {
        private readonly IValidator<BillFormModel> _validator;

        public ValidateBillRequestHandler(IValidator<BillFormModel> validator)
        {
            _validator = validator;
        }

        public Task<ValidationResult> Handle(ValidateBillRequest request, CancellationToken cancellationToken)
        {
            return _validator.ValidateAsync(request.BillFormModel);
        }
    }
}
