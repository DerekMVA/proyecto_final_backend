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
    public class CaracteristicasController : ControllerBase
    {
        private readonly proyecto_final_backendContext _context;

        public CaracteristicasController(proyecto_final_backendContext context)
        {
            _context = context;
        }

        // GET: api/Caracteristicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristica>>> GetCaracteristica()
        {
            return await _context.Caracteristica.Where(x => !x.Deleted).ToListAsync();
        }

        // GET: api/Caracteristicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caracteristica>> GetCaracteristica(int id)
        {
            var caracteristica = await _context.Caracteristica.FindAsync(id);

            if (caracteristica == null || caracteristica.Deleted)
            {
                return NotFound();
            }

            return caracteristica;
        }

        // PUT: api/Caracteristicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristica(int id, Caracteristica caracteristica)
        {
            if (id != caracteristica.Id)
            {
                return BadRequest();
            }

            var existing = await _context.Caracteristica.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (existing == null || existing.Deleted)
            {
                return NotFound();
            }

            caracteristica.Deleted = existing.Deleted;
            _context.Entry(caracteristica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristicaExists(id))
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

        // POST: api/Caracteristicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caracteristica>> PostCaracteristica(Caracteristica caracteristica)
        {
            caracteristica.Deleted = false;
            _context.Caracteristica.Add(caracteristica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaracteristica", new { id = caracteristica.Id }, caracteristica);
        }

        // DELETE (soft): api/Caracteristicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristica(int id)
        {
            var caracteristica = await _context.Caracteristica.FindAsync(id);
            if (caracteristica == null || caracteristica.Deleted)
            {
                return NotFound();
            }

            caracteristica.Deleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Caracteristicas/5/reactivar
        [HttpPost("{id}/reactivar")]
        public async Task<IActionResult> ReactivarCaracteristica(int id)
        {
            var caracteristica = await _context.Caracteristica.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            if (!caracteristica.Deleted)
            {
                return NoContent();
            }
            caracteristica.Deleted = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CaracteristicaExists(int id)
        {
            return _context.Caracteristica.Any(e => e.Id == id);
        }
    }
}
