using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using URESERVE_Api.DAL;

namespace URESERVE_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleReservaProyectorsController : ControllerBase
    {
        private readonly Contexto _context;

        public DetalleReservaProyectorsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/DetalleReservaProyectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReservaProyector>>> GetDetallesReservaProyectores()
        {
            return await _context.DetallesReservaProyectores.ToListAsync();
        }

        // GET: api/DetalleReservaProyectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReservaProyector>> GetDetalleReservaProyector(int id)
        {
            var detalleReservaProyector = await _context.DetallesReservaProyectores.FindAsync(id);

            if (detalleReservaProyector == null)
            {
                return NotFound();
            }

            return detalleReservaProyector;
        }

        // PUT: api/DetalleReservaProyectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReservaProyector(int id, DetalleReservaProyector detalleReservaProyector)
        {
            if (id != detalleReservaProyector.DetalleReservaProyectorId)
            {
                return BadRequest();
            }

            _context.Entry(detalleReservaProyector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReservaProyectorExists(id))
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

        // POST: api/DetalleReservaProyectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReservaProyector>> PostDetalleReservaProyector(DetalleReservaProyector detalleReservaProyector)
        {
            _context.DetallesReservaProyectores.Add(detalleReservaProyector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleReservaProyector", new { id = detalleReservaProyector.DetalleReservaProyectorId }, detalleReservaProyector);
        }

        // DELETE: api/DetalleReservaProyectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReservaProyector(int id)
        {
            var detalleReservaProyector = await _context.DetallesReservaProyectores.FindAsync(id);
            if (detalleReservaProyector == null)
            {
                return NotFound();
            }

            _context.DetallesReservaProyectores.Remove(detalleReservaProyector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReservaProyectorExists(int id)
        {
            return _context.DetallesReservaProyectores.Any(e => e.DetalleReservaProyectorId == id);
        }
    }
}
