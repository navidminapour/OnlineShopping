using Framework.Core.Events;

namespace Sales.Domain.Contracts.Orders.Events
{
    public class AllOrderItemsReserved : DomainEvent
    {
        public long OrderId { get; private set; }
        public int CustomerId { get; private set; }

        public AllOrderItemsReserved(long orderId, int customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}