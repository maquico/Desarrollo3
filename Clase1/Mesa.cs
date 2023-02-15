using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase1
{
    public class Mesa
    {
        public string Nombre { get; set; }
        public string Material { get; set; }
        public int NumeroPatas { get; set; }
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public int Altura { get; set; }

        public Mesa(string nombre, string material, int numeroPatas, int largo, int ancho, int altura)
        {
            Nombre = nombre;
            Material = material;
            NumeroPatas = numeroPatas;
            Largo = largo;
            Ancho = ancho;
            Altura = altura;

        }
    }
}
