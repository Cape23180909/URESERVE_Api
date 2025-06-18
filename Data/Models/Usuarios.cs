using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombres { get; set; }

    [Required]
    [StringLength(100)]
    public string Apellidos { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(150)]
    public string CorreoInstitucional { get; set; }

    [Required]
    [StringLength(100)]
    public string Clave { get; set; }

    // Clave foránea hacia Estudiantes
    public int? EstudianteId { get; set; }
    // Propiedad de navegación
    public Estudiantes? Estudiante { get; set; }
}