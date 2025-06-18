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
    public class DetalleReservaLaboratoriosController : ControllerBase
    {
        private readonly Contexto _context;

        public DetalleReservaLaboratoriosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/DetalleReservaLaboratorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReservaLaboratorio>>> GetDetallesReservaLaboratorios()
        {
            return await _context.DetallesReservaLaboratorios.ToListAsync();
        }

        // GET: api/DetalleReservaLaboratorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReservaLaboratorio>> GetDetalleReservaLaboratorio(int id)
        {
            var detalleReservaLaboratorio = await _context.DetallesReservaLaboratorios.FindAsync(id);

            if (detalleReservaLaboratorio == null)
            {
                return NotFound();
            }

            return detalleReservaLaboratorio;
        }

        // PUT: api/DetalleReservaLaboratorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReservaLaboratorio(int id, DetalleReservaLaboratorio detalleReservaLaboratorio)
        {
            if (id != detalleReservaLaboratorio.DetalleReservaLaboratorioId)
            {
                return BadRequest();
            }

            _context.Entry(detalleReservaLaboratorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReservaLaboratorioExists(id))
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

        // POST: api/DetalleReservaLaboratorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReservaLaboratorio>> PostDetalleReservaLaboratorio(DetalleReservaLaboratorio detalleReservaLaboratorio)
        {
            _context.DetallesReservaLaboratorios.Add(detalleReservaLaboratorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleReservaLaboratorio", new { id = detalleReservaLaboratorio.DetalleReservaLaboratorioId }, detalleReservaLaboratorio);
        }

        // DELETE: api/DetalleReservaLaboratorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReservaLaboratorio(int id)
        {
            var detalleReservaLaboratorio = await _context.DetallesReservaLaboratorios.FindAsync(id);
            if (detalleReservaLaboratorio == null)
            {
                return NotFound();
            }

            _context.DetallesReservaLaboratorios.Remove(detalleReservaLaboratorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReservaLaboratorioExists(int id)
        {
            return _context.DetallesReservaLaboratorios.Any(e => e.DetalleReservaLaboratorioId == id);
        }
    }
}
