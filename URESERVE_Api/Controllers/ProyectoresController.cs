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
    public class ProyectoresController : ControllerBase
    {
        private readonly Contexto _context;

        public ProyectoresController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Proyectores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyectores>>> GetProyectores()
        {
            return await _context.Proyectores.ToListAsync();
        }

        // GET: api/Proyectores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyectores>> GetProyectores(int id)
        {
            var proyectores = await _context.Proyectores.FindAsync(id);

            if (proyectores == null)
            {
                return NotFound();
            }

            return proyectores;
        }

        // PUT: api/Proyectores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectores(int id, Proyectores proyectores)
        {
            if (id != proyectores.ProyectorId)
            {
                return BadRequest();
            }

            _context.Entry(proyectores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoresExists(id))
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

        // POST: api/Proyectores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyectores>> PostProyectores(Proyectores proyectores)
        {
            _context.Proyectores.Add(proyectores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectores", new { id = proyectores.ProyectorId }, proyectores);
        }

        // DELETE: api/Proyectores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectores(int id)
        {
            var proyectores = await _context.Proyectores.FindAsync(id);
            if (proyectores == null)
            {
                return NotFound();
            }

            _context.Proyectores.Remove(proyectores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoresExists(int id)
        {
            return _context.Proyectores.Any(e => e.ProyectorId == id);
        }
    }
}
