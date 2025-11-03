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
    public class GarantiasController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public GarantiasController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/Garantias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garantia>>> GetGarantia()
        {
            return await _context.Garantia.Where(g => !g.Deleted).ToListAsync();
        }

        // GET: api/Garantias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garantia>> GetGarantia(int id)
        {
            var garantia = await _context.Garantia.FindAsync(id);

            if (garantia == null || garantia.Deleted)
            {
                return NotFound();
            }

            return garantia;
        }

        // PUT: api/Garantias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarantia(int id, Garantia garantia)
        {
            if (id != garantia.Id)
            {
                return BadRequest();
            }

            var existing = await _context.Garantia.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            garantia.Deleted = existing.Deleted;
            _context.Entry(garantia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarantiaExists(id))
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

        // POST: api/Garantias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garantia>> PostGarantia(Garantia garantia)
        {
            garantia.Deleted = false;
            _context.Garantia.Add(garantia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarantia", new { id = garantia.Id }, garantia);
        }

        // DELETE (soft): api/Garantias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarantia(int id)
        {
            var garantia = await _context.Garantia.FindAsync(id);
            if (garantia == null || garantia.Deleted)
            {
                return NotFound();
            }

            garantia.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Garantias/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarGarantia(int id)
        {
            var garantia = await _context.Garantia.FindAsync(id);
            if (garantia == null)
            {
                return NotFound();
            }
            if (!garantia.Deleted)
            {
                return NoContent();
            }
            garantia.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GarantiaExists(int id)
        {
            return _context.Garantia.Any(e => e.Id == id);
        }
    }
}
