using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class DetalleReservaRestaurante
{
    [Key]
    public int DetalleReservaRestauranteId { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string CorreoElectronico { get; set; }
}