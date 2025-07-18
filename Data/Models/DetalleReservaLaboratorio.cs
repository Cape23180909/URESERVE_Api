using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models;

public class DetalleReservaLaboratorio
{
    [Key]
    public int DetalleReservaLaboratorioId { get; set; }
    public int CodigoReserva { get; set; }
    public int IdLaboratorio { get; set; }
    public string Matricula { get; set; }

    [JsonConverter(typeof(DominicanDateFormatConverter))]
    public DateTime Fecha { get; set; }  // Se almacena como DateTime pero se serializa como dd-MM-yyyy

    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan Horario { get; set; }
    public int CantidadEstudiantes { get; set; }
    public int Estado { get; set; }

    [JsonIgnore]
    public virtual Laboratorios Laboratorio { get; set; }
}