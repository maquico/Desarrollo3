using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    internal class Estudiante
    {
        public int TipoDocumento { get; set; }

        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Celebridad { get; set; }

        public int Estado { get; set; }
        public decimal PagoInscripcion { get; set; }

        public string Foto { get; set; }
    }
}
