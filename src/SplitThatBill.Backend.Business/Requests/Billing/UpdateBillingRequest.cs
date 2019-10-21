using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Billing
{
    public class UpdateBillingRequest : IRequest<int>
    {
        public UpdateBillingRequest(PersonBillingFormModel personBilling)
        {
            PersonBilling = personBilling;
        }

        public PersonBillingFormModel PersonBilling { get; }
    }
}
