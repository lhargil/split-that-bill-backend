using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Billing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/bills/{id}")]
    public class BillingController : Controller
    {
        private readonly IMediator _mediator;

        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet("billing/{personId}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPut("billing/{personId}")]
        public async Task<ActionResult> Put(int personId, [FromBody]PersonBillingFormModel personBilling)
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

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
