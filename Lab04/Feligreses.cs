using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    internal class Feligreses
    {
        public int id { get; set; }
        public int tipodocumento { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }

        public string apellidos { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public DateTime fechaUltimaConfesion { get; set; }

        public int estadoCivil { get; set; }
        public string sexo { get; set; }

        public int diezma { get; set; }

        public int perteneceAcomunidad { get; set; }

        public DateTime ultimaVisitaIglesia { get; set; }

    }
}
