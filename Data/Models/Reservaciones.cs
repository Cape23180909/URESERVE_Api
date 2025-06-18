using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Reservaciones
{
    [Key]
    public int ReservacionId { get; set; }

    public int CodigoReserva { get; set; }
    public int TipoReserva { get; set; } // 1=restaurante, 2=proyector, 3=laboratorio, 4=cubiculo
    public int CantidadEstudiantes { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Horario { get; set; }
    public int Estado { get; set; } // 1=disponible, 2=en uso, 3=finalizada, 4=cancelada
    public string Matricula { get; set; }
}