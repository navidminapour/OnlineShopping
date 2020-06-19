using System.Diagnostics;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Model.Stocks;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;

namespace Warehouse.Application.CommandHandlers
{
    public class ReserveOrderCommandHandler : IRequestHandler<ReserveOrderCommand, bool>
    {
        private readonly IStockRepository _stockRepository;
        public ReserveOrderCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Task<bool> Handle(ReserveOrderCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("ReserveOrderCommandHandler");
            foreach (var item in request.Items)
            {
                var stock = _stockRepository.GetStockByProduct(item.ProductId);
                stock.Reserve(request.OrderId, request.CustomerId, item.Quantity);
            }

            return Task.FromResult(true);
        }
    }
}
