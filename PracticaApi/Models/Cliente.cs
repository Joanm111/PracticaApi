using System;
using System.Collections.Generic;

namespace PracticaApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Telefonos = new HashSet<Telefono>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? FechaNacimiento { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
