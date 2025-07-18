using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models;
public class DetalleReservaCubiculo
{
    [Key]
    public int DetalleReservaCubiculoId { get; set; }
    public int CodigoReserva { get; set; }
    public int IdCubiculo { get; set; }
    public string Matricula { get; set; }

    [JsonConverter(typeof(DominicanDateFormatConverter))]
    public DateTime Fecha { get; set; }  // Se almacena como DateTime pero se serializa como dd-MM-yyyy

    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan Horario { get; set; }
    public int CantidadEstudiantes { get; set; }
    public int Estado { get; set; }

    [JsonIgnore]
    public virtual Cubiculos Cubiculo { get; set; }
}