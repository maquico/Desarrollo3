using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teo6ConsumirWebService.SR;

namespace Teo6ConsumirWebService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SR.ServicioWebTeo6SoapClient ws = new SR.ServicioWebTeo6SoapClient();
            Console.WriteLine(ws.Sumar(50, 20));

            SR.Cliente cliente = new SR.Cliente()
            {
                Id = 1,
                Nombre = "Angel",
                Apellidos = "Moreno"
            };

            Console.WriteLine(ws.RegistrarCliente(cliente).Texto);
            Console.ReadKey();
        }
    }
}
