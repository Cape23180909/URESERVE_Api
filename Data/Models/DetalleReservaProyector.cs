using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models;

public class DetalleReservaProyector
{
    [Key]
    public int DetalleReservaProyectorId { get; set; }

    // Datos de la reserva
    public int CodigoReserva { get; set; }
    public int IdProyector { get; set; }
    public string Matricula { get; set; }
    public DateTime Fecha { get; set; }

    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan Horario { get; set; }

    public int Estado { get; set; } // 0 = Disponible, 1 = Reservado, etc.

    // Relaciones (ahora nullable)
    public Proyectores? Proyector { get; set; }

}

// TimeSpanConverter para manejar la serialización/deserialización de TimeSpan
public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeSpan.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("hh\\:mm\\:ss"));
    }
}