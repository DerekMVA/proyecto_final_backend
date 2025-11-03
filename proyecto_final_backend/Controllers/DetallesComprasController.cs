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
    public class DetallesComprasController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public DetallesComprasController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/DetallesCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompra>>> GetDetalleCompra()
        {
            return await _context.DetalleCompra.Where(d => !d.Deleted).ToListAsync();
        }

        // GET: api/DetallesCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCompra>> GetDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);

            if (detalleCompra == null || detalleCompra.Deleted)
            {
                return NotFound();
            }

            return detalleCompra;
        }

        // PUT: api/DetallesCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.Id)
            {
                return BadRequest();
            }

            var existing = await _context.DetalleCompra.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            detalleCompra.Deleted = existing.Deleted;
            _context.Entry(detalleCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCompraExists(id))
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

        // POST: api/DetallesCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleCompra>> PostDetalleCompra(DetalleCompra detalleCompra)
        {
            detalleCompra.Deleted = false;
            _context.DetalleCompra.Add(detalleCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCompra", new { id = detalleCompra.Id }, detalleCompra);
        }

        // DELETE (soft): api/DetallesCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);
            if (detalleCompra == null || detalleCompra.Deleted)
            {
                return NotFound();
            }

            detalleCompra.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/DetallesCompras/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarDetalleCompra(int id)
        {
            var detalleCompra = await _context.DetalleCompra.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }
            if (!detalleCompra.Deleted)
            {
                return NoContent();
            }
            detalleCompra.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DetalleCompraExists(int id)
        {
            return _context.DetalleCompra.Any(e => e.Id == id);
        }
    }
}
