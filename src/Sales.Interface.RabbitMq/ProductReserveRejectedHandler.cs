using System.Diagnostics;
using Framework.Core.Events;
using Sales.Interface.Facade.Contracts.Orders.Services;
using System.Threading.Tasks;
using Warehouse.Domain.Contracts.Stocks.Events;

namespace Sales.Interface.RabbitMq
{
    public class ProductReserveRejectedHandler : IIntegrationEventHandler<ProductReserveRejected>
    {
        private readonly IOrderFacadeService _facadeService;
        public ProductReserveRejectedHandler(IOrderFacadeService facadeService)
        {
            _facadeService = facadeService;
        }

        public Task Handle(ProductReserveRejected @event)
        {
            Debug.WriteLine("ProductReserveRejectedHandler");
            return Task.CompletedTask;
        }
    }
}
