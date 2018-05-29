using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoECommerceApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoECommerceApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Carts")]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly FlixOneStoreContext _context;

        public CartsController(FlixOneStoreContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public IEnumerable<Cart> GetCart()
        {
            return _context.Cart;
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromRoute] Guid id, [FromBody] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [HttpPost]
        public async Task<IActionResult> PostCart([FromBody] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cart.Add(cart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _context.Cart.SingleOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(cart);
        }

        private bool CartExists(Guid id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}