using Framework.NH;
using NHibernate;
using System.Linq;
using Framework.Core.Events;
using Warehouse.Domain.Model.Stocks;

namespace Warehouse.Persistence.NH.Repositories
{
    public class StockRepository : BaseNhRepository<long, Stock>, IStockRepository
    {
        public StockRepository(ISession session) : base(session)
        {

        }

        //imagine that each product just exist in one store
        public Stock GetStockByProduct(long productId)
        {
            var stock = Session.Query<Stock>().FirstOrDefault(x => x.Product.Id == productId);
            return stock == null ? null : LoadAggregate(stock.Id);
        }

        public void Add(Stock stock)
        {
            Session.Save(stock);
        }
    }
}
