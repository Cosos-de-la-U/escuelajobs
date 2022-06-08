using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class NonimaAlumno
    {
        public int NominaAlumnoId { get; set; }
        public string? AlumnoId { get; set; }
        public int? GradoId { get; set; }

        public virtual AspNetUser? Alumno { get; set; }
        public virtual Grado? Grado { get; set; }
    }
}
