using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace Lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mesa mesa = new Mesa("Super Mesa 2", "Madera", 4, 50, 30, 50);
            Console.WriteLine("-- Programa 1 -- \n");
            Console.WriteLine("Esta mesa es : {0}, {1}, {2}, {3}, {4}, {5}", mesa.Nombre, mesa.Material, mesa.NumeroPatas, mesa.Largo, mesa.Ancho, mesa.Altura);


            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n\n-- Programa 2 --\n");
                Infidelidad infidelidad = new Infidelidad();
                Console.WriteLine("Ingrese el nombre del afectado: ");
                infidelidad.nombreAfectado = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del afectado: ");
                infidelidad.apellidoAfectado = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del infiel: ");
                infidelidad.nombreInfiel = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del infiel: ");
                infidelidad.apellidoInfiel = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo del infiel: ");
                infidelidad.sexoInfiel = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo del afectado: ");
                infidelidad.sexoAfectado = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha del evento: ");
                string fecha = Console.ReadLine();
                infidelidad.fechaEvento = DateTime.Parse(fecha);
                Console.WriteLine(infidelidad.fechaEvento);
                Console.WriteLine("Ingrese el estado de la pareja (numerico): ");
                infidelidad.estadoPareja = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese False si no es la primera vez o True en caso contrario: ");
                infidelidad.esPrimeraVez = bool.Parse(Console.ReadLine());

                SqlConnection conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Angel\\source\\repos\\Desarrollo3\\Lab01\\db_infidelidad.mdf;Integrated Security=True");
                conexion.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_infidelidad(nombreafectado, apellidoafectado, nombreinfiel, apellidoinfiel, sexoinfiel, sexoafectado, fechaevento, estadopareja, esprimeravez) values(@nombreAfectado, @apellidoAfectado, @nombreInfiel, @apellidoInfiel, @sexoInfiel, @sexoAfectado, @fechaEvento, @estadoPareja, @esPrimeraVez)", conexion);
                cmd.Parameters.AddWithValue("@nombreAfectado", infidelidad.nombreAfectado);
                cmd.Parameters.AddWithValue("@apellidoAfectado", infidelidad.apellidoAfectado);
                cmd.Parameters.AddWithValue("@nombreInfiel", infidelidad.nombreInfiel);
                cmd.Parameters.AddWithValue("@apellidoInfiel", infidelidad.apellidoInfiel);
                cmd.Parameters.AddWithValue("@sexoInfiel", infidelidad.sexoInfiel);
                cmd.Parameters.AddWithValue("@sexoAfectado", infidelidad.sexoAfectado);
                cmd.Parameters.AddWithValue("@fechaEvento", infidelidad.fechaEvento);
                cmd.Parameters.AddWithValue("@estadoPareja", infidelidad.estadoPareja);
                cmd.Parameters.AddWithValue("@esPrimeraVez", infidelidad.esPrimeraVez);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
