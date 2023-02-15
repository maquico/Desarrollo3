using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Clase1;
class programa
{
    static void Main()
    {
       
        Mesa mesa1 = new Mesa("Super Mesa 2", "Madera", 4, 50, 30, 50);
        Console.WriteLine("-- Programa 1 -- ");
        Console.WriteLine("Esta mesa es : {0}, {1}, {2}, {3}, {4}, {5}", mesa1.Nombre, mesa1.Material, mesa1.NumeroPatas, mesa1.Largo, mesa1.Ancho, mesa1.Altura);

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Ingrese el nombre del afectado: ");
            string nombreAfectado = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del afectado: ");
            string apellidoAfectado = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del infiel: ");
            string nombreInfiel = Console.ReadLine();
      
        }

    }
}





