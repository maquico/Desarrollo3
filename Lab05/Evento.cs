using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Evento
    {
        public int codigoGuerra { get; set; }
        public int tipoEvento { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaEvento { get; set; }
        public int cantidadHeridos { get; set; }

        public int cantidadMuertos { get; set; }
    }
}
