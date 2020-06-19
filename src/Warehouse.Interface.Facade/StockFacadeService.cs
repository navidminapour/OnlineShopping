using Framework.Application;
using Sales.Domain.Contracts;
using System;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;
using Warehouse.Interface.Facade.Contracts.Stocks.Services;

namespace Warehouse.Interface.Facade
{
    public class StockFacadeService : IStockFacadeService
    {
        private readonly ICommandBus _bus;

        public StockFacadeService(ICommandBus bus)
        {
            _bus = bus;
        }

        public void ReserveOrder(ReserveOrderCommand reserveOrder)
        {
            _bus.Dispatch(reserveOrder);
        }

        public void AddStock(AddStockCommand addStock)
        {
            _bus.Dispatch(addStock);
        }
    }
}
