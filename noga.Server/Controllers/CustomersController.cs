using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOGA.Server.Models;
using NOGA.Server.Models.CustomerDTO;
using NOGA.Server.Services;

namespace NOGA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerService;

        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }


        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<List<Customers>>> GetCustomersAsync()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }


        // PUT: api/customers/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] Customers updatedCustomer)
        {
            var success = await _customerService.UpdateCustomerAsync(id, updatedCustomer);
            if (!success)
            {
                return NotFound();
            }


            return NoContent();
        }


        // DELETE: api/customers/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);
            if (!success)
            {
                return NotFound(success);
            }
            return Ok(success);
        }



        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }



        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customers>> AddCustomers([FromBody] CustomerDTO newCustomer)
        {
         
                if (newCustomer == null)
                {
                    return BadRequest("Customer data is required.");
                }

                var createdCustomer = await _customerService.AddCustomerAsync(newCustomer);
                return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
            }



    }
}
