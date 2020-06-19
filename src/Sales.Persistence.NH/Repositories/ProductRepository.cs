using Framework.NH;
using NHibernate;
using Sales.Domain.Model.Products;

namespace Sales.Persistence.NH.Repositories
{
    public class ProductRepository : BaseNhRepository<long, Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {

        }

        public Product Get(long id)
        {
            return LoadAggregate(id);
        }
    }
}
