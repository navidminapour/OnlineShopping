using System;
using System.Linq;
using Framework.Core.Events;
using Framework.NH;
using NHibernate;
using Sales.Domain.Model.Categories;
using Sales.Domain.Model.Orders;

namespace Sales.Persistence.NH.Repositories
{
    public class CategoryRepository : BaseNhRepository<int, Category>, ICategoryRepository
    {
        public CategoryRepository(ISession session) : base(session)
        {

        }
    }
}
