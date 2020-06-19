using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Domain.Model.Orders;
using Sales.Domain.Model.Products;
using Sales.Domain.Services;
using Sales.Interface.Facade.Contracts.Orders.Commands;

namespace Sales.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderService = orderService;
        }

        public Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("CreateOrderCommandHandler");
            var id = _orderRepository.GetNextId();

            var order = new Order(id, request.CustomerId,
                request.Items.Select(x => new OrderItem(_productRepository.Get(x.ProductId), x.Quantity)).ToList(), _orderService);

            _orderRepository.Add(order);
            return Task.FromResult(true);
        }
    }
}
