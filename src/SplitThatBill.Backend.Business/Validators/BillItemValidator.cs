using System;
using FluentValidation;
using static SplitThatBill.Backend.Business.Dtos.BillFormModel;

namespace SplitThatBill.Backend.Business.Validators
{
    public class BillItemValidator : AbstractValidator<BillItemFormModel>
    {
        public BillItemValidator()
        {
            RuleFor(m => m.Description)
                .NotEmpty()
                    .WithMessage("The {PropertyName} must not be empty.");
        }
    }
}
