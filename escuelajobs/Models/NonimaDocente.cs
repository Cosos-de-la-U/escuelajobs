using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class NonimaDocente
    {
        public int NominaDocenteId { get; set; }
        public string? DocenteId { get; set; }
        public int? MateriaId { get; set; }
        public int? GradoId { get; set; }

        public virtual AspNetUser? Docente { get; set; }
        public virtual Grado? Grado { get; set; }
        public virtual Materium? Materia { get; set; }
    }
}
