using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products?sortBy=Nombre&sortOrder=asc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string sortBy = "Nombre",
            [FromQuery] string sortOrder = "asc")
        {
            IQueryable<Product> query = _context.Products;

            // Ordenamiento dinámico según campo
            if (sortBy.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
            {
                query = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)
                    ? query.OrderByDescending(p => p.Nombre)
                    : query.OrderBy(p => p.Nombre);
            }
            else if (sortBy.Equals("Precio", StringComparison.OrdinalIgnoreCase))
            {
                query = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase)
                    ? query.OrderByDescending(p => p.Precio)
                    : query.OrderBy(p => p.Precio);
            }
            else
            {
                // Si no coincide con ninguno, ordenar por Id
                query = query.OrderBy(p => p.Id);
            }

            var products = await query.ToListAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductExists(int id)
            => _context.Products.Any(e => e.Id == id);
    }
}
