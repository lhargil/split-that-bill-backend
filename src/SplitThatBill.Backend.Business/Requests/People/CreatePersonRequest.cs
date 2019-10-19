using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class CreatePersonRequest : IRequest<PersonDto>
    {
        public CreatePersonRequest(PersonFormModel personForm)
        {
            PersonForm = personForm;
        }

        public PersonFormModel PersonForm { get; }
    }
}
