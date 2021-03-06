﻿using System;
using System.Collections.Generic;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.Billings
{
    public class UpdatePersonBillingRequest : IRequest<int>
    {
        public UpdatePersonBillingRequest(int personId, PersonBillingFormModel personBilling)
        {
            PersonId = personId;
            PersonBilling = personBilling;
        }

        public int PersonId { get; }
        public PersonBillingFormModel PersonBilling { get; }
    }
}
