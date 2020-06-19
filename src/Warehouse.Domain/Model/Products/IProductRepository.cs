using Framework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Domain.Model.Products
{
    public interface IProductRepository : IRepository<long>
    {
        Product Get(long id);
    }
}
