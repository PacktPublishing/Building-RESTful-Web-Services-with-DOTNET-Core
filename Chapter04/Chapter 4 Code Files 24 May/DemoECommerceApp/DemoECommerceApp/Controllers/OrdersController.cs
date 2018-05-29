using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoECommerceApp.Models;

namespace DemoECommerceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly FlixOneStoreContext _context;

        public OrdersController(FlixOneStoreContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.Include(o => o.OrdersProducts).SingleOrDefaultAsync(m => m.Id == id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders([FromRoute] Guid id, [FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrders([FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Copy customer address to delivery address.
            orders.Deliverycity = orders.Customercity;
            orders.Deliverycountry = orders.Customercountry;
            orders.Deliverystreetaddress = orders.CustomerStreetaddress;
            orders.Deliverypostalcode = orders.Customerpostalcode;
            orders.Deliverystate = orders.Customerstate;

            // Retrieve customer details and add to order.
            if (orders.Customerid != null)
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == orders.Customerid);
                if (customer != null)
                {
                    orders.Deliveryname = orders.Customername = customer.Firstname;
                    orders.Customeremail = customer.Email;
                    orders.Customertelephone = customer.Telephone;
                }
            }

            _context.Orders.Add(orders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (OrdersExists(orders.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrders", new { id = orders.Id }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return Ok(orders);
        }

        private bool OrdersExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}