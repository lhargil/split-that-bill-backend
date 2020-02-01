using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, PersonDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;
        private readonly IExternalIdGenerator _externalIdGenerator;

        public CreatePersonRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper, IExternalIdGenerator externalIdGenerator)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
            _externalIdGenerator = externalIdGenerator;
        }

        public async Task<PersonDto> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = new Person(request.PersonForm.Firstname, request.PersonForm.Lastname);
            person.SetExternalId(_externalIdGenerator.Generate());

            _splitThatBillContext.People.Add(person);
            await _splitThatBillContext.SaveChangesAsync();

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
    }
}
