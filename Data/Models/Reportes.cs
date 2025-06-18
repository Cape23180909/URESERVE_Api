using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Reportes
{
    [Key]
    public int ReporteId { get; set; }
    public int TipoReporte { get; set; } // 1=proyectores, 2=cubiculos, 3=laboratorios, 4=restaurante
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public DateTime FechaGeneracion { get; set; }
    public string GeneradoPor { get; set; } // Matrícula o ID del administrador

    // Datos del reporte (podrían ser propiedades adicionales o una relación con otra tabla)
    public int TotalReservas { get; set; }
    public int ReservasActivas { get; set; }
    public int ReservasCanceladas { get; set; }
}