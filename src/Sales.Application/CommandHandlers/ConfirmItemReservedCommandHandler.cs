using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Domain.Model.Orders;
using Sales.Interface.Facade.Contracts.Orders.Commands;

namespace Sales.Application.CommandHandlers
{
    public class ConfirmItemReservedCommandHandler : IRequestHandler<ConfirmItemReservedCommand, bool>
    {
        private readonly IOrderRepository _repository;

        public ConfirmItemReservedCommandHandler(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }

        public Task<bool> Handle(ConfirmItemReservedCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("ConfirmItemReservedCommandHandler");

            var order = _repository.Get(request.OrderId);
            order.ConfirmReservedItem(request.ProductId);
            return Task.FromResult(true);
        }
    }
}
