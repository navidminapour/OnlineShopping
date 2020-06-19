using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Warehouse.Domain.Model.Products;
using Warehouse.Domain.Model.Stocks;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;

namespace Warehouse.Application.CommandHandlers
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, bool>
    {
        private readonly IStockRepository _stockRepository;

        public AddStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public Task<bool> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("AddStockCommandHandler");
            var id =_stockRepository.GetNextId();
            var stock = new Stock(id,new Product(1,1,1,1), request.Quantity);
            _stockRepository.Add(stock);
            return Task.FromResult(true);
        }
    }
}