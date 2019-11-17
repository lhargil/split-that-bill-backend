using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;
using SplitThatBill.Backend.Business.Requests.Billings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        private readonly IMediator _mediator;

        public BillsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<BillDto>>> Get()
        {
            var bills = await _mediator.Send(new GetBillsRequest());
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillDto>> Get(int id)
        {
            try
            {
                var bill = await _mediator.Send(new GetSingleBillRequest(id));
                return Ok(bill);
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<BillItemDto>> Post([FromBody]BillFormModel bill)
        {
            if (null == bill)
            {
                throw new ArgumentNullException(nameof(bill), "The bill details submitted is null.");
            }

            var validateResult = await _mediator.Send(new ValidateBillRequest(bill));

            if (!validateResult.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createResult = await _mediator.Send(new CreateBillRequest(bill));

            return CreatedAtAction(nameof(this.Get), new { id = createResult.Id }, createResult);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]BillFormModel bill)
        {
            if (null == bill)
            {
                throw new ArgumentNullException(nameof(bill), "The bill details submitted is null.");
            }

            var validateResult = await _mediator.Send(new ValidateBillRequest(bill));

            if (!validateResult.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _mediator.Send(new UpdateBillRequest(id, bill));

            if (updated)
            {
                return NoContent();
            }

            return BadRequest("The bill cannot be updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _mediator.Send(new DeleteBillRequest(id));
                return NoContent();
            }
            catch (NullReferenceException nullReferenceException)
            {
                return NotFound(nullReferenceException.Message);
            }
        }
    }
}
