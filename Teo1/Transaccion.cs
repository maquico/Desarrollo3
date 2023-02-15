using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teo1
{
    internal class Transaccion
    {
        public int id { get; set; }
        public int tipoDocumento  { get; set; }

        public string documento { get; set; }

        public decimal monto { get; set; }
        public DateTime fechaTransaccion { get; set; }

        public string debitoCredito { get; set; }

        public int tipoTransaccion { get; set; }

        public string descripcion { get; set; }
    }
}
