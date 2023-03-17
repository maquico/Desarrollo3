using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab06Web
{
    public class Verdugo
    {
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaEvento { get; set; }

        public int CantidadHijos { get; set; }

        public bool Vivo { get; set; }

        public bool Preso { get; set; }
    }
}