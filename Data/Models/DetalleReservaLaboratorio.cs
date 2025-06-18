using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class DetalleReservaLaboratorio
{
    [Key]
    public int DetalleReservaLaboratorioId { get; set; }
    public int CodigoReserva { get; set; }
    public int IdLaboratorio { get; set; }
    public string Matricula { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Horario { get; set; }
    public int CantidadEstudiantes { get; set; }
    public int Estado { get; set; }

    public Reservaciones Reservacion { get; set; }
    public Laboratorios Laboratorio { get; set; }
    public Estudiantes Estudiante { get; set; }
}