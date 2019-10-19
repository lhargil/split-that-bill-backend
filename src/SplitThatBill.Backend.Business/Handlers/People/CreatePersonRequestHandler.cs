using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, PersonDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public CreatePersonRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = new Person(request.PersonForm.Firstname, request.PersonForm.Lastname);

            _splitThatBillContext.People.Add(person);
            await _splitThatBillContext.SaveChangesAsync();

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
    }
}
