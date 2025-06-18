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
    public class ReportesController : ControllerBase
    {
        private readonly Contexto _context;

        public ReportesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Reportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reportes>>> GetReportes()
        {
            return await _context.Reportes.ToListAsync();
        }

        // GET: api/Reportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reportes>> GetReportes(int id)
        {
            var reportes = await _context.Reportes.FindAsync(id);

            if (reportes == null)
            {
                return NotFound();
            }

            return reportes;
        }

        // PUT: api/Reportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportes(int id, Reportes reportes)
        {
            if (id != reportes.ReporteId)
            {
                return BadRequest();
            }

            _context.Entry(reportes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportesExists(id))
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

        // POST: api/Reportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reportes>> PostReportes(Reportes reportes)
        {
            _context.Reportes.Add(reportes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportes", new { id = reportes.ReporteId }, reportes);
        }

        // DELETE: api/Reportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportes(int id)
        {
            var reportes = await _context.Reportes.FindAsync(id);
            if (reportes == null)
            {
                return NotFound();
            }

            _context.Reportes.Remove(reportes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportesExists(int id)
        {
            return _context.Reportes.Any(e => e.ReporteId == id);
        }
    }
}
