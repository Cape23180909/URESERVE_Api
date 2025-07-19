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
    public class ReservacionesController : ControllerBase
    {
        private readonly Contexto _context;

        public ReservacionesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Reservaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> GetReservaciones()
        {
            return await _context.Reservaciones.ToListAsync();
        }

        // GET: api/Reservaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservaciones>> GetReservaciones(int id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);

            if (reservaciones == null)
            {
                return NotFound();
            }

            return reservaciones;
        }

        // PUT: api/Reservaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaciones(int id, Reservaciones reservaciones)
        {
            if (id != reservaciones.ReservacionId)
            {
                return BadRequest();
            }

            _context.Entry(reservaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionesExists(id))
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

        // POST: api/Reservaciones
        [HttpPost]
        public async Task<ActionResult<Reservaciones>> PostReservaciones(
            [FromBody] ReservacionesDto reservacionDto)
        {
            // Mapear el DTO a la entidad Reservaciones
            var reservacion = new Reservaciones
            {
                CodigoReserva = reservacionDto.CodigoReserva,
                TipoReserva = reservacionDto.TipoReserva,
                CantidadEstudiantes = reservacionDto.CantidadEstudiantes,
                Fecha = DateTime.Parse(reservacionDto.Fecha),
                HoraInicio = TimeSpan.Parse(reservacionDto.HoraInicio), // Nueva propiedad
                HoraFin = TimeSpan.Parse(reservacionDto.HoraFin),       // Nueva propiedad
                Estado = reservacionDto.Estado,
                Matricula = reservacionDto.Matricula
            };

            _context.Reservaciones.Add(reservacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaciones", new { id = reservacion.ReservacionId }, reservacion);
        }

        // DELETE: api/Reservaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaciones(int id)
        {
            var reservaciones = await _context.Reservaciones.FindAsync(id);
            if (reservaciones == null)
            {
                return NotFound();
            }

            _context.Reservaciones.Remove(reservaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Reservaciones/usuario/2021-0422
        [HttpGet("usuario/{matricula}")]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> GetReservacionesByMatricula(string matricula)
        {
            var reservas = await _context.Reservaciones
                .Where(r => r.Matricula == matricula)
                .ToListAsync();

            if (reservas == null || !reservas.Any())
            {
                return NotFound($"No se encontraron reservaciones para la matrícula: {matricula}");
            }

            return Ok(reservas);
        }

        private bool ReservacionesExists(int id)
        {
            return _context.Reservaciones.Any(e => e.ReservacionId == id);
        }
    }

    // Clase DTO para recibir los datos desde Android
    public class ReservacionesDto
    {
        public int ReservacionId { get; set; }
        public int CodigoReserva { get; set; }
        public int TipoReserva { get; set; }
        public int CantidadEstudiantes { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; } // Nueva propiedad
        public string HoraFin { get; set; }    // Nueva propiedad
        public int Estado { get; set; }
        public string Matricula { get; set; }
    }
}