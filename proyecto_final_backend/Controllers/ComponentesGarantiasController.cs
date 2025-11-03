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
    public class ComponentesGarantiasController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public ComponentesGarantiasController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/ComponentesGarantias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteGarantia>>> GetComponenteGarantia()
        {
            return await _context.ComponenteGarantia.ToListAsync();
        }

        // GET: api/ComponentesGarantias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteGarantia>> GetComponenteGarantia(int id)
        {
            var componenteGarantia = await _context.ComponenteGarantia.FindAsync(id);

            if (componenteGarantia == null)
            {
                return NotFound();
            }

            return componenteGarantia;
        }

        // PUT: api/ComponentesGarantias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponenteGarantia(int id, ComponenteGarantia componenteGarantia)
        {
            if (id != componenteGarantia.Id)
            {
                return BadRequest();
            }

            _context.Entry(componenteGarantia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteGarantiaExists(id))
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

        // POST: api/ComponentesGarantias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponenteGarantia>> PostComponenteGarantia(ComponenteGarantia componenteGarantia)
        {
            _context.ComponenteGarantia.Add(componenteGarantia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponenteGarantia", new { id = componenteGarantia.Id }, componenteGarantia);
        }

        // DELETE: api/ComponentesGarantias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponenteGarantia(int id)
        {
            var componenteGarantia = await _context.ComponenteGarantia.FindAsync(id);
            if (componenteGarantia == null)
            {
                return NotFound();
            }

            _context.ComponenteGarantia.Remove(componenteGarantia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponenteGarantiaExists(int id)
        {
            return _context.ComponenteGarantia.Any(e => e.Id == id);
        }
    }
}
