using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Guerra
    {
        public int codigoGuerra { get; set; }
        public string pais1 { get; set; }

        public string pais2 { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string paisGanador { get; set; }
        public int cantidadMuertos { get; set; }
        public int cantidadPresos { get; set; }
        public int heridos { get; set; }
        public int estadoGuerra { get; set; }
        public int perdidaFinanciera { get; set; }
    }
}
