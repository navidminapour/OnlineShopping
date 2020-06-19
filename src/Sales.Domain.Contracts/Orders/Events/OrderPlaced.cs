using Framework.Core.Events;
using System.Collections.Generic;

namespace Sales.Domain.Contracts.Orders.Events
{
    public class OrderPlaced : DomainEvent
    {
        public long OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public List<OrderPlacedItem> Items { get; private set; }

        public OrderPlaced(long orderId, int customerId, List<OrderPlacedItem> items)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
        }
    }

    public class OrderPlacedItem
    {
        public long ProductId { get; private set; }
        public int Quantity { get; private set; }

        public OrderPlacedItem(long productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
