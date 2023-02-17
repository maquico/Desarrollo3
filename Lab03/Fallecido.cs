using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Fallecido
    {
        public int Id { get; set; }
        public int TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public int Estado { get; set; }

    }
}
