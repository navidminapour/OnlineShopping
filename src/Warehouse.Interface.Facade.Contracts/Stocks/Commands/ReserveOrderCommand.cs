using Framework.Application;
using System.Collections.Generic;

namespace Warehouse.Interface.Facade.Contracts.Stocks.Commands
{
    public class ReserveOrderCommand : Command
    {
        public long OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<ReserveOrderItem> Items { get; set; }

        public ReserveOrderCommand(long orderId, int customerId, List<ReserveOrderItem> items)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
        }
    }

    public class ReserveOrderItem
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public ReserveOrderItem(long productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
