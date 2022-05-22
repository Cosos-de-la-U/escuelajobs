using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class NonimaDocente
    {
        public NonimaDocente()
        {
            Nota = new HashSet<Notum>();
        }

        public int NominaDocenteId { get; set; }
        public int? DocenteId { get; set; }
        public int? MateriaId { get; set; }
        public int? GradoId { get; set; }

        public virtual Docente? Docente { get; set; }
        public virtual Grado? Grado { get; set; }
        public virtual Materium? Materia { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
