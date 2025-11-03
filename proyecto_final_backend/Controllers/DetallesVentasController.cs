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
    public class DetallesVentasController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public DetallesVentasController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/DetallesVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetalleVenta()
        {
            return await _context.DetalleVenta.Where(d => !d.Deleted).ToListAsync();
        }

        // GET: api/DetallesVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);

            if (detalleVenta == null || detalleVenta.Deleted)
            {
                return NotFound();
            }

            return detalleVenta;
        }

        // PUT: api/DetallesVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.Id)
            {
                return BadRequest();
            }

            var existing = await _context.DetalleVenta.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            detalleVenta.Deleted = existing.Deleted;
            _context.Entry(detalleVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentaExists(id))
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

        // POST: api/DetallesVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detalleVenta)
        {
            detalleVenta.Deleted = false;
            _context.DetalleVenta.Add(detalleVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleVenta", new { id = detalleVenta.Id }, detalleVenta);
        }

        // DELETE (soft): api/DetallesVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta == null || detalleVenta.Deleted)
            {
                return NotFound();
            }

            detalleVenta.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/DetallesVentas/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound();
            }
            if (!detalleVenta.Deleted)
            {
                return NoContent();
            }
            detalleVenta.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DetalleVentaExists(int id)
        {
            return _context.DetalleVenta.Any(e => e.Id == id);
        }
    }
}
