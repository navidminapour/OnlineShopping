using Sales.Domain.Services;

namespace Sales.Domain.Model.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public bool HasAnyPendingOrders(long customerId)
        {
            return _repository.HasAnyPendingOrders(customerId);
        }
    }
}
