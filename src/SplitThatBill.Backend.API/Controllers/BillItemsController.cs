using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
        public void Post(int id, [FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{billItemId}")]
        public void Put(int id, int billItemId, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{billItemId}")]
        public void Delete(int id, int billItemId)
        {
        }
    }
}
