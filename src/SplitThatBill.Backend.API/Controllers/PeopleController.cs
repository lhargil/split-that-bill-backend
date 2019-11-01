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

        //TODO: deprecated, should be deleted. This is moved to billingsController
        [HttpGet("{id}/items")]
        public async Task<ActionResult<PersonBillItemsDto>> GetPersonBillItems(int id)
        {
            try
            {
                var personBillItems = await _mediator.Send(new GetPersonBillItemsRequest(id));
                return personBillItems;
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson([FromBody] PersonFormModel personForm)
        {
            try
            {
                if (null == personForm)
                {
                    throw new ArgumentNullException(nameof(personForm), "Person data is invalid.");
                }

                var createdResult = await _mediator.Send(new CreatePersonRequest(personForm));
                return CreatedAtAction(nameof(this.GetPerson), new { id = createdResult.Id }, createdResult);
            }
            catch (ArgumentNullException argNullException)
            {
                return BadRequest(argNullException.Message);
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson(int id, [FromBody] PersonFormModel personForm)
        {
            try
            {
                if (null == personForm)
                {
                    throw new ArgumentNullException(nameof(personForm), "Person data is invalid.");
                }

                var updatedResult = await _mediator.Send(new UpdatePersonRequest(id, personForm));
                return NoContent();
            }
            catch (ArgumentNullException argNullException)
            {
                return BadRequest(argNullException.Message);
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
        }
    }
}
