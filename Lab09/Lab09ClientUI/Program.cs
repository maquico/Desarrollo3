using Lab09ClientUI.ds_ClienteTableAdapters;
using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab09ClientUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Cliente UI";

            var endpointConfiguration = new EndpointConfiguration("ClientUI");
            

            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            // Replace with:
            await RunLoop(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);

            await endpointInstance.Stop().ConfigureAwait(false);

        }

        static ILog log = LogManager.GetLogger<Program>();

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
                
                log.Info("Escriba E para colocar una orden y S para salir");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        // Instantiate the command
                        var orden = new PlaceOrder();
                        Console.WriteLine("Descripcion");
                        orden.Descripcion = Console.ReadLine();
                        Console.WriteLine("Precio");
                        orden.Precio = int.Parse(Console.ReadLine());
                        Console.WriteLine("Cantidad");
                        orden.Cantidad = int.Parse(Console.ReadLine());
                        Console.WriteLine("ITBIS");
                        orden.Cantidad = int.Parse(Console.ReadLine());

                        adapter.SP_InsertOrden(orden.Descripcion, orden.Precio, orden.Cantidad, orden.ITBIS);

                        // Send the command to the local endpoint
                        log.Info($"Enviando orden, descripcion de la orden: {orden.Descripcion}");
                        await endpointInstance.Send(orden)
                            .ConfigureAwait(false);

                        break;

                    case ConsoleKey.S:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
