﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teo1
{
    internal class Cliente
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Estado { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Agregados
        public string Sexo { get; set; }
        public string Comentario { get; set; }

        //Agregados en TEO 2

        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public decimal Balance { get; set; }

    }
}
