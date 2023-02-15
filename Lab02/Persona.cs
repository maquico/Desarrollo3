using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Persona
    {
        public int id { get; set; }
        public int tipoDocumento { get; set; }
        public string documento { get; set; }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string sexo { get; set; }
        public int estado { get; set; }
        public string nacionalidad { get; set; }
        public string paisOrigen { get; set; }
        public int cantidad { get; set; }
    }
}
