using Framework.Core.Events;

namespace Warehouse.Domain.Contracts.Stocks.Events
{
    public class ProductReserveRejected : DomainEvent
    {
        public long OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public long ProductId { get; private set; }
        public int RequestedQuantity { get; set; }
        public int AvailableCount { get; set; }

        public ProductReserveRejected(long orderId, int customerId, long productId, int requestedQuantity, int availableCount)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ProductId = productId;
            RequestedQuantity = requestedQuantity;
            AvailableCount = availableCount;
        }
    }
}
