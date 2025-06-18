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
    public class CubiculosController : ControllerBase
    {
        private readonly Contexto _context;

        public CubiculosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Cubiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cubiculos>>> GetCubiculos()
        {
            return await _context.Cubiculos.ToListAsync();
        }

        // GET: api/Cubiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cubiculos>> GetCubiculos(int id)
        {
            var cubiculos = await _context.Cubiculos.FindAsync(id);

            if (cubiculos == null)
            {
                return NotFound();
            }

            return cubiculos;
        }

        // PUT: api/Cubiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCubiculos(int id, Cubiculos cubiculos)
        {
            if (id != cubiculos.CubiculoId)
            {
                return BadRequest();
            }

            _context.Entry(cubiculos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubiculosExists(id))
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

        // POST: api/Cubiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cubiculos>> PostCubiculos(Cubiculos cubiculos)
        {
            _context.Cubiculos.Add(cubiculos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCubiculos", new { id = cubiculos.CubiculoId }, cubiculos);
        }

        // DELETE: api/Cubiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCubiculos(int id)
        {
            var cubiculos = await _context.Cubiculos.FindAsync(id);
            if (cubiculos == null)
            {
                return NotFound();
            }

            _context.Cubiculos.Remove(cubiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CubiculosExists(int id)
        {
            return _context.Cubiculos.Any(e => e.CubiculoId == id);
        }
    }
}
