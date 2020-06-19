using System.Linq;
using Framework.NH;
using NHibernate;
using Sales.Domain.Model.Orders;

namespace Sales.Persistence.NH.Repositories
{
    public class OrderRepository : BaseNhRepository<long, Order>, IOrderRepository
    {
        public OrderRepository(ISession session) : base(session)
        {

        }

        public bool HasAnyPendingOrders(long customerId)
        {
            return Session.Query<Order>()
                .Any(x => x.CustomerId == customerId && x.OrderState == OrderState.Placed || x.OrderState == OrderState.Reserved);
        }

        public void Add(Order order)
        {
            Session.Save(order);
        }

        public Order Get(long id)
        {
            return LoadAggregate(id);
        }
    }
}
