using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
}