using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class Grado
    {
        public Grado()
        {
            NonimaAlumnos = new HashSet<NonimaAlumno>();
            NonimaDocentes = new HashSet<NonimaDocente>();
            Nota = new HashSet<Notum>();
        }

        public int GradoId { get; set; }
        public string? Grado1 { get; set; }

        public virtual ICollection<NonimaAlumno> NonimaAlumnos { get; set; }
        public virtual ICollection<NonimaDocente> NonimaDocentes { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
