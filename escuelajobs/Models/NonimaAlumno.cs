using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class NonimaAlumno
    {
        public int NominaAlumnoId { get; set; }
        public int? AlumnoId { get; set; }
        public int? GradoId { get; set; }

        public virtual Alumno? Alumno { get; set; }
        public virtual Grado? Grado { get; set; }
    }
}
