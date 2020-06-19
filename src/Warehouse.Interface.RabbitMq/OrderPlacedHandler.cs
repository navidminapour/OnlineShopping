using System.Diagnostics;
using Framework.Core.Events;
using Sales.Domain.Contracts.Orders.Events;
using System.Threading.Tasks;
using Warehouse.Interface.Facade.Contracts.Stocks.Services;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;
using System.Linq;

namespace Warehouse.Interface.RabbitMq
{
    public class OrderPlacedHandler : IIntegrationEventHandler<OrderPlaced>
    {
        private readonly IStockFacadeService _facadeService;
        public OrderPlacedHandler(IStockFacadeService facadeService)
        {
            _facadeService = facadeService;
        }

        public Task Handle(OrderPlaced @event)
        {
            Debug.WriteLine("OrderPlacedHandler");
            _facadeService.ReserveOrder(new ReserveOrderCommand(@event.OrderId, @event.CustomerId, 
                @event.Items.Select(x => new ReserveOrderItem(x.ProductId, x.Quantity)).ToList()));
            return Task.CompletedTask;
        }
    }
}
