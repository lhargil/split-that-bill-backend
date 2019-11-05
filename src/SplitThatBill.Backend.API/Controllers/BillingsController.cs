using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Billings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/bills/{id}")]
    public class BillingsController : Controller
    {
        private readonly IMediator _mediator;

        public BillingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("billings")]
        public async Task<ActionResult> GetBillings(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetBillingsRequest(id));

                return Ok(result);
            }
            catch (NullReferenceException nex)
            {
                return NotFound(nex.Message);
            }
        }

        // GET: api/values
        [HttpGet("billings/{personId}")]
        public async Task<ActionResult<PersonBillItemsDto>> GetPersonBillings(int id, int personId)
        {
            try
            {
                var result = await _mediator.Send(new GetPersonBillingRequest(personId));

                return Ok(result);
            }
            catch (NullReferenceException nex)
            {
                return NotFound(nex.Message);
            }
        }

        // POST api/values
        [HttpPut("billings/{personId}")]
        public async Task<ActionResult> Put(int id, int personId, [FromBody]PersonBillingFormModel personBilling)
        {
            try
            {
                var result = await _mediator.Send(new UpdatePersonBillingRequest(personId, personBilling));

                return NoContent();
            }
            catch (ArgumentNullException anex)
            {
                return BadRequest(anex.Message);
            }
            catch (NullReferenceException nex)
            {
                return NotFound(nex.Message);
            }
        }
    }
}
