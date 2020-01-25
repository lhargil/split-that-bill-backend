using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Validators
{
    public class BillValidator : AbstractValidator<BillFormModel>
    {
        public BillValidator()
        {
            RuleFor(m => m.EstablishmentName)
                .NotEmpty()
                    .WithMessage("The {PropertyName} must not be empty.");

            //RuleFor(m => m.BillItems)
            //    .Must(BeAtLeastOne)
            //        .WithMessage("There must be at least one bill item in a bill.");

            //RuleForEach(m => m.BillItems)
            //    .SetValidator(new BillItemValidator());
        }

        //private bool BeAtLeastOne(List<BillItemFormModel> arg)
        //{
        //    return arg.Any();
        //}
    }
}
