using System;
using System.Collections.Generic;

namespace PracticaApi.Models
{
    public partial class Plane
    {
        public Plane()
        {
            Telefonos = new HashSet<Telefono>();
        }

        public string IdPlan { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Renta { get; set; }
        public decimal CostoMin { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
