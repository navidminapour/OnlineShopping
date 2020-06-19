using Framework.Core;
using Sales.Domain.Model.Products;

namespace Sales.Domain.Model.Products
{
    public interface IProductRepository : IRepository<long>
    {
        Product Get(long id);
    }
}