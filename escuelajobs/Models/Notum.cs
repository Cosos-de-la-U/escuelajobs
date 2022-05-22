using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class Notum
    {
        public int NotaId { get; set; }
        public int? AlumnoId { get; set; }
        public int? DocenteId { get; set; }
        public int? MateriaId { get; set; }
        public int? GradoId { get; set; }
        public int? CalificacionId { get; set; }

        public virtual Alumno? Alumno { get; set; }
        public virtual Calificacion? Calificacion { get; set; }
        public virtual NonimaDocente? Docente { get; set; }
        public virtual Grado? Grado { get; set; }
        public virtual Materium? Materia { get; set; }
    }
}
