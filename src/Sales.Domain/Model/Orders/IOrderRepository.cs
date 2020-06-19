using Framework.Core;

namespace Sales.Domain.Model.Orders
{
    public interface IOrderRepository : IRepository<long>
    {
        bool HasAnyPendingOrders(long customerId);
        void Add(Order order);
        Order Get(long id);
    }
}