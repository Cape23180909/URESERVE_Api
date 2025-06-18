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
    public class TipoCargoesController : ControllerBase
    {
        private readonly Contexto _context;

        public TipoCargoesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TipoCargoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCargo>>> GetTiposCargo()
        {
            return await _context.TiposCargo.ToListAsync();
        }

        // GET: api/TipoCargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCargo>> GetTipoCargo(int id)
        {
            var tipoCargo = await _context.TiposCargo.FindAsync(id);

            if (tipoCargo == null)
            {
                return NotFound();
            }

            return tipoCargo;
        }

        // PUT: api/TipoCargoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCargo(int id, TipoCargo tipoCargo)
        {
            if (id != tipoCargo.TipoCargoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCargoExists(id))
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

        // POST: api/TipoCargoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCargo>> PostTipoCargo(TipoCargo tipoCargo)
        {
            _context.TiposCargo.Add(tipoCargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCargo", new { id = tipoCargo.TipoCargoId }, tipoCargo);
        }

        // DELETE: api/TipoCargoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCargo(int id)
        {
            var tipoCargo = await _context.TiposCargo.FindAsync(id);
            if (tipoCargo == null)
            {
                return NotFound();
            }

            _context.TiposCargo.Remove(tipoCargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCargoExists(int id)
        {
            return _context.TiposCargo.Any(e => e.TipoCargoId == id);
        }
    }
}
