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
    public class DetalleReservaRestaurantesController : ControllerBase
    {
        private readonly Contexto _context;

        public DetalleReservaRestaurantesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/DetalleReservaRestaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReservaRestaurante>>> GetDetallesReservaRestaurantes()
        {
            return await _context.DetallesReservaRestaurantes.ToListAsync();
        }

        // GET: api/DetalleReservaRestaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReservaRestaurante>> GetDetalleReservaRestaurante(int id)
        {
            var detalleReservaRestaurante = await _context.DetallesReservaRestaurantes.FindAsync(id);

            if (detalleReservaRestaurante == null)
            {
                return NotFound();
            }

            return detalleReservaRestaurante;
        }

        // PUT: api/DetalleReservaRestaurantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReservaRestaurante(int id, DetalleReservaRestaurante detalleReservaRestaurante)
        {
            if (id != detalleReservaRestaurante.DetalleReservaRestauranteId)
            {
                return BadRequest();
            }

            _context.Entry(detalleReservaRestaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReservaRestauranteExists(id))
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

        // POST: api/DetalleReservaRestaurantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReservaRestaurante>> PostDetalleReservaRestaurante(DetalleReservaRestaurante detalleReservaRestaurante)
        {
            _context.DetallesReservaRestaurantes.Add(detalleReservaRestaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleReservaRestaurante", new { id = detalleReservaRestaurante.DetalleReservaRestauranteId }, detalleReservaRestaurante);
        }

        // DELETE: api/DetalleReservaRestaurantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReservaRestaurante(int id)
        {
            var detalleReservaRestaurante = await _context.DetallesReservaRestaurantes.FindAsync(id);
            if (detalleReservaRestaurante == null)
            {
                return NotFound();
            }

            _context.DetallesReservaRestaurantes.Remove(detalleReservaRestaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReservaRestauranteExists(int id)
        {
            return _context.DetallesReservaRestaurantes.Any(e => e.DetalleReservaRestauranteId == id);
        }
    }
}
