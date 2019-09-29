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
    public class GetPeopleRequestHandler : IRequestHandler<GetPeopleRequest, List<PersonDto>>
    {
        private readonly SplitThatBillContext _context;
        private readonly IMapper _mapper;

        public GetPeopleRequestHandler(SplitThatBillContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PersonDto>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = await _context.Set<Person>()
                .Select(person => _mapper.Map<PersonDto>(person))
                .ToListAsync();

            return people;
        }
    }
}
