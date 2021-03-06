﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/bills/{id}/[controller]")]
    public class BillItemsController : Controller
    {
        private readonly IMediator _mediator;

        public BillItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<BillItemDto>>> Get(int id)
        {
            var billItems = await _mediator.Send(new GetBillItemsListRequest(id));

            return Ok(billItems);
        }

        // GET api/values/5
        [HttpGet("{billItemId}")]
        public async Task<ActionResult<BillItemDto>> Get(int id, int billItemId)
        {
            try
            {
                var billItem = await _mediator.Send(new GetSingleBillItemRequest(id, billItemId));

                return Ok(billItem);
            }
            catch (NullReferenceException nullRefException)
            {
                return NotFound(nullRefException.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<BillItemDto>> Post(int id, [FromBody]BillItemFormModel form)
        {

            try
            {
                if (null == form)
                {
                    throw new ArgumentNullException(nameof(form), "The bill item data is null.");
                }

                var createResult = await _mediator.Send(new CreateBillItemRequest(id, form));

                return CreatedAtAction(nameof(this.Get), new { id, billItemId = createResult.Id }, createResult);
            }
            catch (ArgumentNullException argumentNullException)
            {
                return BadRequest(argumentNullException.Message);
            }
            catch (NullReferenceException nullReferenceException)
            {
                return NotFound(nullReferenceException.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{billItemId}")]
        public async Task<ActionResult> Put(int id, int billItemId, [FromBody]BillItemFormModel form)
        {
            try
            {
                if (null == form)
                {
                    throw new ArgumentNullException(nameof(form), "The bill item data is null.");
                }

                var updated = await _mediator.Send(new UpdateBillItemRequest(id, billItemId, form));

                if (updated)
                {
                    return NoContent();
                }
                throw new Exception("The bill item cannot be updated.");
            }
            catch (ArgumentNullException argumentNullException)
            {
                return BadRequest(argumentNullException.Message);
            }
            catch (NullReferenceException nullReferenceException)
            {
                return NotFound(nullReferenceException.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{billItemId}")]
        public async Task<ActionResult> Delete(int id, int billItemId)
        {
            try
            {
                var deleted = await _mediator.Send(new DeleteBillItemRequest(id, billItemId));
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
