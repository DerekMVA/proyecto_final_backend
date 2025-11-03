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
    public class ComponentesReparacionesController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public ComponentesReparacionesController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/ComponentesReparaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteReparacion>>> GetComponenteReparacion()
        {
            return await _context.ComponenteReparacion.ToListAsync();
        }

        // GET: api/ComponentesReparaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteReparacion>> GetComponenteReparacion(int id)
        {
            var componenteReparacion = await _context.ComponenteReparacion.FindAsync(id);

            if (componenteReparacion == null)
            {
                return NotFound();
            }

            return componenteReparacion;
        }

        // PUT: api/ComponentesReparaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponenteReparacion(int id, ComponenteReparacion componenteReparacion)
        {
            if (id != componenteReparacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(componenteReparacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteReparacionExists(id))
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

        // POST: api/ComponentesReparaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponenteReparacion>> PostComponenteReparacion(ComponenteReparacion componenteReparacion)
        {
            _context.ComponenteReparacion.Add(componenteReparacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponenteReparacion", new { id = componenteReparacion.Id }, componenteReparacion);
        }

        // DELETE: api/ComponentesReparaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponenteReparacion(int id)
        {
            var componenteReparacion = await _context.ComponenteReparacion.FindAsync(id);
            if (componenteReparacion == null)
            {
                return NotFound();
            }

            _context.ComponenteReparacion.Remove(componenteReparacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponenteReparacionExists(int id)
        {
            return _context.ComponenteReparacion.Any(e => e.Id == id);
        }
    }
}
