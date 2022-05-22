using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class Calificacion
    {
        public Calificacion()
        {
            Nota = new HashSet<Notum>();
        }

        public int CalificacionId { get; set; }
        public decimal? CalificacionUno { get; set; }
        public decimal? CalificacionDos { get; set; }
        public decimal? CalificacionTres { get; set; }
        public decimal? CalificacionCuatro { get; set; }
        public decimal? CalificacionTotal { get; set; }

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
