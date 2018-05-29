using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoECommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DemoECommerceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly FlixOneStoreContext _context;

        public CustomersController(FlixOneStoreContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Basic")]
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //For Basic -> [Authorize(AuthenticationSchemes = "Basic")]
        [Authorize]
        public async Task<IActionResult> GetCustomers([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ident = User.Identity as ClaimsIdentity;
            var currentLoggeedInUserId = ident.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (currentLoggeedInUserId != id.ToString())
            {
                // Not Authorized
                return BadRequest("You are not authorized!");
            }

            var customers = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Basic")]
        public async Task<IActionResult> PutCustomers([FromRoute] Guid id, [FromBody] Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.Id)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomers([FromBody] Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Unique mail id check.
            if (_context.Customers.Any(x => x.Email == customers.Email))
            {
                ModelState.AddModelError("email", "User with mail id already exists!");
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customers);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CustomersExists(customers.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Basic")]
        public async Task<IActionResult> DeleteCustomers([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customers = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return Ok(customers);
        }

        private bool CustomersExists(Guid id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}