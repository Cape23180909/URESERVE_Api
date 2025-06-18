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
    public class DetalleReservaCubiculoesController : ControllerBase
    {
        private readonly Contexto _context;

        public DetalleReservaCubiculoesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/DetalleReservaCubiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReservaCubiculo>>> GetDetallesReservaCubiculos()
        {
            return await _context.DetallesReservaCubiculos.ToListAsync();
        }

        // GET: api/DetalleReservaCubiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReservaCubiculo>> GetDetalleReservaCubiculo(int id)
        {
            var detalleReservaCubiculo = await _context.DetallesReservaCubiculos.FindAsync(id);

            if (detalleReservaCubiculo == null)
            {
                return NotFound();
            }

            return detalleReservaCubiculo;
        }

        // PUT: api/DetalleReservaCubiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReservaCubiculo(int id, DetalleReservaCubiculo detalleReservaCubiculo)
        {
            if (id != detalleReservaCubiculo.DetalleReservaCubiculoId)
            {
                return BadRequest();
            }

            _context.Entry(detalleReservaCubiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReservaCubiculoExists(id))
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

        // POST: api/DetalleReservaCubiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReservaCubiculo>> PostDetalleReservaCubiculo(DetalleReservaCubiculo detalleReservaCubiculo)
        {
            _context.DetallesReservaCubiculos.Add(detalleReservaCubiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleReservaCubiculo", new { id = detalleReservaCubiculo.DetalleReservaCubiculoId }, detalleReservaCubiculo);
        }

        // DELETE: api/DetalleReservaCubiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReservaCubiculo(int id)
        {
            var detalleReservaCubiculo = await _context.DetallesReservaCubiculos.FindAsync(id);
            if (detalleReservaCubiculo == null)
            {
                return NotFound();
            }

            _context.DetallesReservaCubiculos.Remove(detalleReservaCubiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReservaCubiculoExists(int id)
        {
            return _context.DetallesReservaCubiculos.Any(e => e.DetalleReservaCubiculoId == id);
        }
    }
}
