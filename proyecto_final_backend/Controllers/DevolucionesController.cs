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
    public class DevolucionesController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public DevolucionesController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/Devoluciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucion>>> GetDevolucion()
        {
            return await _context.Devolucion.Where(d => !d.Deleted).ToListAsync();
        }

        // GET: api/Devoluciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucion>> GetDevolucion(int id)
        {
            var devolucion = await _context.Devolucion.FindAsync(id);

            if (devolucion == null || devolucion.Deleted)
            {
                return NotFound();
            }

            return devolucion;
        }

        // PUT: api/Devoluciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucion(int id, Devolucion devolucion)
        {
            if (id != devolucion.Id)
            {
                return BadRequest();
            }

            var existing = await _context.Devolucion.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            devolucion.Deleted = existing.Deleted;
            _context.Entry(devolucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevolucionExists(id))
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

        // POST: api/Devoluciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devolucion>> PostDevolucion(Devolucion devolucion)
        {
            devolucion.Deleted = false;
            _context.Devolucion.Add(devolucion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevolucion", new { id = devolucion.Id }, devolucion);
        }

        // DELETE (soft): api/Devoluciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucion(int id)
        {
            var devolucion = await _context.Devolucion.FindAsync(id);
            if (devolucion == null || devolucion.Deleted)
            {
                return NotFound();
            }

            devolucion.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Devoluciones/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarDevolucion(int id)
        {
            var devolucion = await _context.Devolucion.FindAsync(id);
            if (devolucion == null)
            {
                return NotFound();
            }
            if (!devolucion.Deleted)
            {
                return NoContent();
            }
            devolucion.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DevolucionExists(int id)
        {
            return _context.Devolucion.Any(e => e.Id == id);
        }
    }
}
