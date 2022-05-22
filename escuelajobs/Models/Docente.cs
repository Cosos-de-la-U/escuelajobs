using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class Docente
    {
        public Docente()
        {
            NonimaDocentes = new HashSet<NonimaDocente>();
        }

        public int DocenteId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FecNac { get; set; }
        public string? UsuarioId { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<NonimaDocente> NonimaDocentes { get; set; }
    }
}
