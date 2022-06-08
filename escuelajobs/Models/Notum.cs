using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class Notum
    {
        public int NotaId { get; set; }
        public string? AlumnoId { get; set; }
        public string? DocenteId { get; set; }
        public int? MateriaId { get; set; }
        public int? GradoId { get; set; }
        public int? CalificacionId { get; set; }

        public virtual AspNetUser? Alumno { get; set; }
        public virtual Calificacion? Calificacion { get; set; }
        public virtual AspNetUser? Docente { get; set; }
        public virtual Grado? Grado { get; set; }
        public virtual Materium? Materia { get; set; }
    }
}
