using Framework.Core.Events;
using System.Collections.Generic;

namespace Warehouse.Domain.Contracts.Stocks.Events
{
    public class ProductReserved : DomainEvent
    {
        public long OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public long ProductId { get; private set; }
        public int ReservedCount { get; set; }

        public ProductReserved(long orderId, int customerId,long productId, int reservedCount)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ProductId = productId;
            ReservedCount = reservedCount;
        }
    }
}
