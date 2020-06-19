using System.Diagnostics;
using Framework.Core.Events;
using Sales.Interface.Facade.Contracts.Orders.Commands;
using Sales.Interface.Facade.Contracts.Orders.Services;
using System.Threading.Tasks;
using Warehouse.Domain.Contracts.Stocks.Events;

namespace Sales.Interface.RabbitMq
{
    public class ProductReservedHandler : IIntegrationEventHandler<ProductReserved>
    {
        private readonly IOrderFacadeService _facadeService;
        public ProductReservedHandler(IOrderFacadeService facadeService)
        {
            _facadeService = facadeService;
        }

        public Task Handle(ProductReserved @event)
        {
            Debug.WriteLine("ProductReservedHandler");
            _facadeService.ConfirmReservedItem(new ConfirmItemReservedCommand(@event.OrderId, @event.ProductId));

            return Task.CompletedTask;
        }
    }
}
