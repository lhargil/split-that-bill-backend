using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class UpdatePersonRequestHandler : IRequestHandler<UpdatePersonRequest, PersonDto>
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IMapper _mapper;

        public UpdatePersonRequestHandler(SplitThatBillContext splitThatBillContext, IMapper mapper)
        {
            _splitThatBillContext = splitThatBillContext;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _splitThatBillContext.People.FindAsync(request.Id);

            if (null == person)
            {
                throw new NullReferenceException("The person is not found.");
            }

            person.Update(request.PersonForm.Firstname, request.PersonForm.Lastname);

            await _splitThatBillContext.SaveChangesAsync();

            return _mapper.Map<PersonDto>(person);
        }
    }
}
