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

    // Información del inventario
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public string Conectividad { get; set; }  // Ej: HDMI, VGA, USB
}