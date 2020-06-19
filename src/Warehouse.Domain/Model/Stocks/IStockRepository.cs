using Framework.Core;

namespace Warehouse.Domain.Model.Stocks
{
    public interface IStockRepository : IRepository<long>
    {
        Stock GetStockByProduct(long productId);
        void Add(Stock stock);
    }
}
