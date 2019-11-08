using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.People;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/people/{id}/[controller]")]
    public class PaymentDetailsController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<PaymentDetailDto>>> GetPaymentDetails(int id)
        {
            try
            {
                var paymentDetailsList = await _mediator.Send(new GetPaymentDetailsRequest(id));
                return Ok(paymentDetailsList);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{paymentDetailsId}")]
        public async Task<ActionResult<PaymentDetailDto>> GetPaymentDetail(int id, int paymentDetailsId)
        {
            try
            {
                var paymentDetails = await _mediator.Send(new GetSinglePaymentDetailsRequest(id, paymentDetailsId));
                return Ok(paymentDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreatePaymentDetail(int id, [FromBody]PersonPaymentDetailsFormModel personPaymentDetails)
        {
            try
            {
                var createdResult = await _mediator.Send(new CreatePaymentDetailRequest(id, personPaymentDetails));

                return CreatedAtAction(nameof(this.GetPaymentDetail), new { id, paymentDetailsId = createdResult.Id }, createdResult);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{paymentDetailsId}")]
        public async Task<ActionResult> UpdatePaymentDetail(int id, int paymentDetailsId, [FromBody]PersonPaymentDetailsFormModel personPaymentDetailsFormModel)
        {
            try
            {
                var updatedResult = await _mediator.Send(new UpdatePaymentDetailRequest(id, paymentDetailsId, personPaymentDetailsFormModel));
                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{paymentDetailsId}")]
        public async Task<ActionResult> DeletePaymentDetails(int id, int paymentDetailsId)
        {
            try
            {
                var deletedResult = await _mediator.Send(new DeletePaymentDetailsRequest(id, paymentDetailsId));

                return NoContent();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
