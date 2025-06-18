using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;
public class Estudiantes
{
    [Key]
    public int EstudianteId { get; set; }

    public string Matricula { get; set; }
    public string Facultad { get; set; }
    public string Carrera { get; set; }
}