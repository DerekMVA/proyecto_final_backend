using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_final_backend.Data;
using proyecto_final_backend.Models;

namespace proyecto_final_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosCarritoController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public ProductosCarritoController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/ProductosCarrito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoCarrito>>> GetProductoCarrito()
        {
            return await _context.ProductoCarrito.Where(pc => !pc.Deleted).ToListAsync();
        }

        // GET: api/ProductosCarrito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoCarrito>> GetProductoCarrito(int id)
        {
            var productoCarrito = await _context.ProductoCarrito.FindAsync(id);

            if (productoCarrito == null || productoCarrito.Deleted)
            {
                return NotFound();
            }

            return productoCarrito;
        }

        // PUT: api/ProductosCarrito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoCarrito(int id, ProductoCarrito productoCarrito)
        {
            if (id != productoCarrito.Id)
            {
                return BadRequest();
            }

            var existing = await _context.ProductoCarrito.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            productoCarrito.Deleted = existing.Deleted;
            _context.Entry(productoCarrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoCarritoExists(id))
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

        // POST: api/ProductosCarrito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoCarrito>> PostProductoCarrito(ProductoCarrito productoCarrito)
        {
            productoCarrito.Deleted = false;
            _context.ProductoCarrito.Add(productoCarrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoCarrito", new { id = productoCarrito.Id }, productoCarrito);
        }

        // DELETE (soft): api/ProductosCarrito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoCarrito(int id)
        {
            var productoCarrito = await _context.ProductoCarrito.FindAsync(id);
            if (productoCarrito == null || productoCarrito.Deleted)
            {
                return NotFound();
            }

            productoCarrito.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ProductosCarrito/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarProductoCarrito(int id)
        {
            var productoCarrito = await _context.ProductoCarrito.FindAsync(id);
            if (productoCarrito == null)
            {
                return NotFound();
            }
            if (!productoCarrito.Deleted)
            {
                return NoContent();
            }
            productoCarrito.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProductoCarritoExists(int id)
        {
            return _context.ProductoCarrito.Any(e => e.Id == id);
        }
    }
}
