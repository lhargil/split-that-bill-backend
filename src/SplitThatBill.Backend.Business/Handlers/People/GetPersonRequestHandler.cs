using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;
using SplitThatBill.Backend.Core.Entities;
using SplitThatBill.Backend.Data;

namespace SplitThatBill.Backend.Business.Handlers.People
{
    public class GetPersonRequestHandler : IRequestHandler<GetPersonRequest, PersonDto>
    {
        private readonly SplitThatBillContext _context;
        private readonly IMapper _mapper;

        public GetPersonRequestHandler(SplitThatBillContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _context.People
                .FirstOrDefaultAsync(p => p.Id == request.PersonId);

            if (null == person) throw new NullReferenceException("The person was not found.");

            return _mapper.Map<PersonDto>(person);
        }
    }
}
