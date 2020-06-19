using Warehouse.Interface.Facade.Contracts.Stocks.Commands;

namespace Warehouse.Interface.Facade.Contracts.Stocks.Services
{
    public interface IStockFacadeService
    {
        void ReserveOrder(ReserveOrderCommand reserveOrder);
        void AddStock(AddStockCommand addStock);
    }
}
