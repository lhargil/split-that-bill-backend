using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Business.Dtos;
using SplitThatBill.Backend.Business.Requests.Currencies;

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrenciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/values
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<CurrencyDto>>> Get()
        {
            var currencies = await _mediator.Send(new GetCurrenciesRequest());
            return Ok(currencies);
        }
    }
}