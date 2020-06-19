using Framework.NH;
using NHibernate;
using System;
using Warehouse.Domain.Model.Products;

namespace Warehouse.Persistence.NH.Repositories
{
    public class ProductRepository : BaseNhRepository<long, Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session)
        {

        }
        public Product Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}