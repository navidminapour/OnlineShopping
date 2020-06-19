using Framework.Application;

namespace Warehouse.Interface.Facade.Contracts.Stocks.Commands
{
    public class AddStockCommand : Command
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
