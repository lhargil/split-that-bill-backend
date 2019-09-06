using System;
using FluentValidation.Results;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests
{
    public class ValidateBillRequest : IRequest<ValidationResult>
    {
        public ValidateBillRequest(BillFormModel billFormModel)
        {
            BillFormModel = billFormModel;
        }

        public BillFormModel BillFormModel { get; }
    }
}
