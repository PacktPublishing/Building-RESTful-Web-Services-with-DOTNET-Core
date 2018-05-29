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
    [Route("api/Productsdetails")]
    public class ProductsdetailsController : Controller
    {
        private readonly FlixOneStoreContext _context;

        public ProductsdetailsController(FlixOneStoreContext context)
        {
            _context = context;
        }

        // GET: api/Productsdetails
        [HttpGet]
        public IEnumerable<Productsdetail> GetProductsdetail()
        {
            return _context.Productsdetail;
        }

        // GET: api/Productsdetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsdetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productsdetail = await _context.Productsdetail.SingleOrDefaultAsync(m => m.Id == id);

            if (productsdetail == null)
            {
                return NotFound();
            }

            return Ok(productsdetail);
        }

        // PUT: api/Productsdetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsdetail([FromRoute] Guid id, [FromBody] Productsdetail productsdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productsdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsdetailExists(id))
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

        // POST: api/Productsdetails
        [HttpPost]
        public async Task<IActionResult> PostProductsdetail([FromBody] Productsdetail productsdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Productsdetail.Add(productsdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductsdetailExists(productsdetail.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductsdetail", new { id = productsdetail.Id }, productsdetail);
        }

        // DELETE: api/Productsdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsdetail([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productsdetail = await _context.Productsdetail.SingleOrDefaultAsync(m => m.Id == id);
            if (productsdetail == null)
            {
                return NotFound();
            }

            _context.Productsdetail.Remove(productsdetail);
            await _context.SaveChangesAsync();

            return Ok(productsdetail);
        }

        private bool ProductsdetailExists(Guid id)
        {
            return _context.Productsdetail.Any(e => e.Id == id);
        }
    }
}