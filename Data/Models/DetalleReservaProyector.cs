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

    [Required]
    public int CodigoReserva { get; set; }

    [Required]
    public int IdProyector { get; set; }

    [Required]
    public string Matricula { get; set; }

    [JsonConverter(typeof(DominicanDateFormatConverter))]
    public DateTime Fecha { get; set; }  // Se almacena como DateTime pero se serializa como dd-MM-yyyy

    [JsonConverter(typeof(TimeSpanConverter))]
    public TimeSpan Horario { get; set; }

    public int Estado { get; set; } // 0 = Disponible, 1 = Reservado, etc.

    [JsonIgnore]
    public virtual Proyectores? Proyector { get; set; }
}

public class DominicanDateFormatConverter : JsonConverter<DateTime>
{
    private const string Format = "dd-MM-yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return DateTime.ParseExact(reader.GetString(), Format, null);
        }
        catch (Exception ex)
        {
            throw new JsonException($"Formato de fecha inválido. Use {Format}.", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}

public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeSpan.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(@"hh\:mm\:ss"));
    }
}