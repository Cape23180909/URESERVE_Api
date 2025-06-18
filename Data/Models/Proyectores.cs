using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Proyectores
{
    [Key]
    public int ProyectorId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Horario { get; set; }
    public int Estado { get; set; }
    public int CodigoReserva { get; set; }
}