using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    internal class Infidelidad
    {
        public int id { get; set; }
        public string nombreAfectado { get; set; }
        
        public string apellidoAfectado { get; set; }

        public string nombreInfiel { get; set; }

        public string apellidoInfiel { get; set; }

        public string sexoInfiel { get; set; }
        public string sexoAfectado { get; set; }

        public DateTime fechaEvento { get; set; }

        public int estadoPareja { get; set; }

        public bool esPrimeraVez { get; set; }
    }
}
