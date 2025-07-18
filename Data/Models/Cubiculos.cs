using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Cubiculos
{
    [Key]
    public int CubiculoId { get; set; }

    public string Nombre { get; set; }

    public bool Disponible { get; set; }
}