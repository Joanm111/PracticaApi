using System;
using System.Collections.Generic;

namespace PracticaApi.Models
{
    public partial class Telefono
    {
        public Telefono()
        {
            Llamada = new HashSet<Llamada>();
        }

        public string Telefono1 { get; set; } = null!;
        public int IdCliente { get; set; }
        public string TipoPlan { get; set; } = null!;

        public virtual Cliente? IdClienteNavigation { get; set; } = null!;
        public virtual Plane?TipoPlanNavigation { get; set; } = null!;
        public virtual ICollection<Llamada> Llamada { get; set; }
    }
}
