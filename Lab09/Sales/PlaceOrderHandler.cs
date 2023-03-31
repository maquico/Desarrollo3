using Messages;
using NServiceBus;
using NServiceBus.Logging;
using Sales.ds_VentasTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    public class PlaceOrderHandler :
    IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Mensaje recibido en ventas, descripcion del mensaje: {message.Descripcion}");
            var ordenColocada = new OrderPlaced
            {
                Descripcion = message.Descripcion,
                Precio = message.Precio,
                Cantidad = message.Cantidad,
                ITBIS = message.ITBIS
            };
            tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
            adapter.SP_InsertOrden(ordenColocada.Descripcion, ordenColocada.Precio, ordenColocada.Cantidad, ordenColocada.ITBIS);
            return context.Publish(ordenColocada);
        }
    }
}
