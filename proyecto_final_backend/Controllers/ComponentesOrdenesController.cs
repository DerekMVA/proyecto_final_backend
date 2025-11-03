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
    public class ComponentesOrdenesController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public ComponentesOrdenesController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/ComponentesOrdenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteOrden>>> GetComponenteOrden()
        {
            return await _context.ComponenteOrden.ToListAsync();
        }

        // GET: api/ComponentesOrdenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteOrden>> GetComponenteOrden(int id)
        {
            var componenteOrden = await _context.ComponenteOrden.FindAsync(id);

            if (componenteOrden == null)
            {
                return NotFound();
            }

            return componenteOrden;
        }

        // PUT: api/ComponentesOrdenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponenteOrden(int id, ComponenteOrden componenteOrden)
        {
            if (id != componenteOrden.Id)
            {
                return BadRequest();
            }

            _context.Entry(componenteOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteOrdenExists(id))
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

        // POST: api/ComponentesOrdenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponenteOrden>> PostComponenteOrden(ComponenteOrden componenteOrden)
        {
            _context.ComponenteOrden.Add(componenteOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponenteOrden", new { id = componenteOrden.Id }, componenteOrden);
        }

        // DELETE: api/ComponentesOrdenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponenteOrden(int id)
        {
            var componenteOrden = await _context.ComponenteOrden.FindAsync(id);
            if (componenteOrden == null)
            {
                return NotFound();
            }

            _context.ComponenteOrden.Remove(componenteOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponenteOrdenExists(int id)
        {
            return _context.ComponenteOrden.Any(e => e.Id == id);
        }
    }
}
