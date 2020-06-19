using Framework.Core;
using Sales.Interface.Facade.Contracts.Orders.Commands;

namespace Sales.Interface.Facade.Contracts.Orders.Services
{
    public interface IOrderFacadeService : IFacadeService
    {
        long CreateOrder(CreateOrderCommand command);
        void ConfirmReservedItem(ConfirmItemReservedCommand command);
    }
}