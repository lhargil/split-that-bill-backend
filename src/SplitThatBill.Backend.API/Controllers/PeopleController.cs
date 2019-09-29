using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> GetPeople()
        {
            var people = await _mediator.Send(new GetPeopleRequest());

            return people;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
            try
            {
                var person = await _mediator.Send(new GetPersonRequest(id));
                return person;
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
        }
    }
}
