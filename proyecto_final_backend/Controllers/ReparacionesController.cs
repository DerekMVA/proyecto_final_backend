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
    public class ReparacionesController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public ReparacionesController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/Reparaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reparacion>>> GetReparacion()
        {
            return await _context.Reparacion.Where(r => !r.Deleted).ToListAsync();
        }

        // GET: api/Reparaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reparacion>> GetReparacion(int id)
        {
            var reparacion = await _context.Reparacion.FindAsync(id);

            if (reparacion == null || reparacion.Deleted)
            {
                return NotFound();
            }

            return reparacion;
        }

        // PUT: api/Reparaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReparacion(int id, Reparacion reparacion)
        {
            if (id != reparacion.Id)
            {
                return BadRequest();
            }

            var existing = await _context.Reparacion.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            reparacion.Deleted = existing.Deleted;
            _context.Entry(reparacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReparacionExists(id))
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

        // POST: api/Reparaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reparacion>> PostReparacion(Reparacion reparacion)
        {
            reparacion.Deleted = false;
            _context.Reparacion.Add(reparacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReparacion", new { id = reparacion.Id }, reparacion);
        }

        // DELETE (soft): api/Reparaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReparacion(int id)
        {
            var reparacion = await _context.Reparacion.FindAsync(id);
            if (reparacion == null || reparacion.Deleted)
            {
                return NotFound();
            }

            reparacion.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Reparaciones/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarReparacion(int id)
        {
            var reparacion = await _context.Reparacion.FindAsync(id);
            if (reparacion == null)
            {
                return NotFound();
            }
            if (!reparacion.Deleted)
            {
                return NoContent();
            }
            reparacion.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ReparacionExists(int id)
        {
            return _context.Reparacion.Any(e => e.Id == id);
        }
    }
}
