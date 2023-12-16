using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _customer.GetCustomers();
            if (response == null) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customer)
        {
            var response = await _customer.PostCustomer(customer);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpPut("{idCustomer:int}")]
        public async Task<ActionResult> Put(int idCustomer,[FromBody] CustomerDTO customer)
        {
            var response = await _customer.PutCustomer(idCustomer, customer);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }

        [HttpDelete("{idCustomer:int}")]
        public async Task<ActionResult> Delete(int idCustomer)
        {
            var response = await _customer.DeleteCustomer(idCustomer);
            if (response) { return BadRequest(response); } else { return Ok(response); }
        }
    }
}
