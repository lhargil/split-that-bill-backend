using FluentValidation;
using SplitThatBill.Backend.Business.Dtos;

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
