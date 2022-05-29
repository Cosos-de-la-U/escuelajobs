using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    [Authorize(Roles = "Administrator,Alumno,Docente")]
    public partial class Alumno
    {
        public Alumno()
        {
            NonimaAlumnos = new HashSet<NonimaAlumno>();
            Nota = new HashSet<Notum>();
        }

        public int AlumnoId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FecNac { get; set; }
        public string? UsuarioId { get; set; }

        public virtual ICollection<NonimaAlumno> NonimaAlumnos { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
