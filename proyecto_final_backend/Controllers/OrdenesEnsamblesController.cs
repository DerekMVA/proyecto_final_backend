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
    public class OrdenesEnsamblesController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public OrdenesEnsamblesController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesEnsambles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenEnsamble>>> GetOrdenEnsamble()
        {
            return await _context.OrdenEnsamble.Where(o => !o.Deleted).ToListAsync();
        }

        // GET: api/OrdenesEnsambles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenEnsamble>> GetOrdenEnsamble(int id)
        {
            var ordenEnsamble = await _context.OrdenEnsamble.FindAsync(id);

            if (ordenEnsamble == null || ordenEnsamble.Deleted)
            {
                return NotFound();
            }

            return ordenEnsamble;
        }

        // PUT: api/OrdenesEnsambles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenEnsamble(int id, OrdenEnsamble ordenEnsamble)
        {
            if (id != ordenEnsamble.Id)
            {
                return BadRequest();
            }

            var existing = await _context.OrdenEnsamble.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            ordenEnsamble.Deleted = existing.Deleted;
            _context.Entry(ordenEnsamble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenEnsambleExists(id))
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

        // POST: api/OrdenesEnsambles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenEnsamble>> PostOrdenEnsamble(OrdenEnsamble ordenEnsamble)
        {
            ordenEnsamble.Deleted = false;
            _context.OrdenEnsamble.Add(ordenEnsamble);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenEnsamble", new { id = ordenEnsamble.Id }, ordenEnsamble);
        }

        // DELETE (soft): api/OrdenesEnsambles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenEnsamble(int id)
        {
            var ordenEnsamble = await _context.OrdenEnsamble.FindAsync(id);
            if (ordenEnsamble == null || ordenEnsamble.Deleted)
            {
                return NotFound();
            }

            ordenEnsamble.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/OrdenesEnsambles/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarOrdenEnsamble(int id)
        {
            var ordenEnsamble = await _context.OrdenEnsamble.FindAsync(id);
            if (ordenEnsamble == null)
            {
                return NotFound();
            }
            if (!ordenEnsamble.Deleted)
            {
                return NoContent();
            }
            ordenEnsamble.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrdenEnsambleExists(int id)
        {
            return _context.OrdenEnsamble.Any(e => e.Id == id);
        }
    }
}
