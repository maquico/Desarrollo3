using Billing.ds_FacturacionTableAdapters;
using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class OrderPlacedHandler :
    IHandleMessages<OrderPlaced>
    {
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            log.Info($"Orden colocada en facturacion, Descripcion: {message.Descripcion}");

            OrderPlaced ordenColocada2 = new OrderPlaced();
            ordenColocada2.Descripcion = message.Descripcion;
            ordenColocada2.Cantidad = message.Cantidad;
            ordenColocada2.Precio = message.Precio;
            ordenColocada2.ITBIS = message.ITBIS;

            tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
            adapter.SP_InsertOrden(ordenColocada2.Descripcion, ordenColocada2.Precio, ordenColocada2.Cantidad, ordenColocada2.ITBIS);
            return Task.CompletedTask;
        }
    }
}
