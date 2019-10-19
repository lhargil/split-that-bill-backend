using System;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;

namespace SplitThatBill.Backend.Business.Requests.People
{
    public class UpdatePersonRequest : IRequest<PersonDto>
    {
        public UpdatePersonRequest(int id, PersonFormModel personForm)
        {
            Id = id;
            PersonForm = personForm;
        }

        public int Id { get; }
        public PersonFormModel PersonForm { get; }
    }
}
