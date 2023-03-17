using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06Consola
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            while (true)
            {
                SR.servicio_lab6SoapClient ws = new SR.servicio_lab6SoapClient();
                SR.Verdugo verdugo = new SR.Verdugo();
                SR.Indicios indicio = new SR.Indicios();

                Console.WriteLine($"\n\n--- DATOS VERDUGO ---\n\n");
                Console.WriteLine("Tipo documento: ");
                verdugo.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                verdugo.Documento = Console.ReadLine();
                Console.WriteLine("Nombres: ");
                verdugo.Nombres = Console.ReadLine();
                Console.WriteLine("Apellidos: ");
                verdugo.Apellidos = Console.ReadLine();
                Console.WriteLine("Fecha nacimiento: ");
                string fechaNac = Console.ReadLine();
                verdugo.FechaNacimiento = DateTime.Parse(fechaNac);
                Console.WriteLine("Fecha evento: ");
                string fechaFin = Console.ReadLine();
                verdugo.FechaEvento = DateTime.Parse(fechaFin);
                Console.WriteLine("Cantidad Hijos: ");
                verdugo.CantidadHijos = int.Parse(Console.ReadLine());
                Console.WriteLine("Vivo: ");
                verdugo.Vivo = bool.Parse(Console.ReadLine());
                Console.WriteLine("Preso: ");
                verdugo.Preso = bool.Parse(Console.ReadLine());

                indicio.TipoDocumento = verdugo.TipoDocumento;
                indicio.Documento = verdugo.Documento;
                Console.WriteLine($"\n\n--- DATOS INDICIO ---\n\n");
                Console.WriteLine("Descripcion");
                indicio.Descripcion = Console.ReadLine();

                SR.Respuesta respuesta = ws.RegistrarVerdugoIndicio(verdugo, indicio);
                log.Info("Log en consola recibido");
                Console.WriteLine($"{respuesta.Mensaje}");
            }
            
        }
    }
}
