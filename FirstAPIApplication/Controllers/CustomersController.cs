using ClassModels;
using FirstAPIApplication.Data;
using FirstAPIApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase, ICustomerService
    {
        private CustomerDBContext _dbContext;

        public CustomersController(CustomerDBContext customerDB)
        {
            _dbContext = customerDB;
        }

        [HttpPost]
        public async Task AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var delete = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (delete == null) return NotFound();
            _dbContext.Customers.Remove(delete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
           var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
           return customer == null ? NotFound() : Ok(customer);
        }

        [HttpGet]
        public async Task<IReadOnlyList<Customer>> GetCustomers()
        {
           return await _dbContext.Customers.ToListAsync();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCustomer(int id,Customer customer)
        {
          if (id != customer.Id) return BadRequest();

           _dbContext.Customers.Update(customer);
           await _dbContext.SaveChangesAsync();
            return NoContent();    
        }
    }
}
