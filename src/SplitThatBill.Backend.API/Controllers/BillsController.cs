using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SplitThatBill.Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class BillsController : Controller
    {
        private readonly SplitThatBillContext _splitThatBillContext;
        private readonly IDateTimeManager _dateTimeManager;

        public BillsController(SplitThatBillContext splitThatBillContext)
        {
            _splitThatBillContext = splitThatBillContext;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<int>> Get()
        {
            return Ok(1);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
