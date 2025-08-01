using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class TarjetaCredito
{
    [Key]
    public int TarjetaCreditoId { get; set; }
    public string numeroTarjeta { get; set; }
    public string nombreTitular { get; set; }
    public string fechaVencimiento { get; set; }
    public string codigoSeguridad { get; set; }
}   