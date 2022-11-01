using System;
using System.Collections.Generic;

namespace PracticaApi.Models
{
    public partial class Llamada
    {
        public int CodLlamada { get; set; }
        public string Telefono { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public int Duracion { get; set; }

        public virtual Telefono? TelefonoNavigation { get; set; } = null!;
    }
}
