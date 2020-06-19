using Framework.Application;
using System.Collections.Generic;

namespace Sales.Interface.Facade.Contracts.Orders.Commands
{
    public class CreateOrderCommand : Command
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItem> Items { get; set; }
    }

    public class CreateOrderItem
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}