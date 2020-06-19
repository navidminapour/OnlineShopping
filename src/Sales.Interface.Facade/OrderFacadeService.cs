using Framework.Application;
using Sales.Interface.Facade.Contracts.Orders.Commands;
using Sales.Interface.Facade.Contracts.Orders.Services;

namespace Sales.Interface.Facade
{
    public class OrderFacadeService : IOrderFacadeService
    {
        private readonly ICommandBus _bus;

        public OrderFacadeService(ICommandBus bus)
        {
            _bus = bus;
        }

        public long CreateOrder(CreateOrderCommand command)
        {
            _bus.Dispatch(command);
            return 0;
        }

        public void ConfirmReservedItem(ConfirmItemReservedCommand command)
        {
            _bus.Dispatch(command);
        }
    }
}
