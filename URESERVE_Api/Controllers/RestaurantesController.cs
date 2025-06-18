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
    public class RestaurantesController : ControllerBase
    {
        private readonly Contexto _context;

        public RestaurantesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurantes>>> GetRestaurantes()
        {
            return await _context.Restaurantes.ToListAsync();
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurantes>> GetRestaurantes(int id)
        {
            var restaurantes = await _context.Restaurantes.FindAsync(id);

            if (restaurantes == null)
            {
                return NotFound();
            }

            return restaurantes;
        }

        // PUT: api/Restaurantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantes(int id, Restaurantes restaurantes)
        {
            if (id != restaurantes.RestauranteId)
            {
                return BadRequest();
            }

            _context.Entry(restaurantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantesExists(id))
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

        // POST: api/Restaurantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurantes>> PostRestaurantes(Restaurantes restaurantes)
        {
            _context.Restaurantes.Add(restaurantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantes", new { id = restaurantes.RestauranteId }, restaurantes);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantes(int id)
        {
            var restaurantes = await _context.Restaurantes.FindAsync(id);
            if (restaurantes == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantesExists(int id)
        {
            return _context.Restaurantes.Any(e => e.RestauranteId == id);
        }
    }
}
