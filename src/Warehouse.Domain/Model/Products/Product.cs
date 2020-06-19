using Framework.Domain;

namespace Warehouse.Domain.Model.Products
{
    public class Product : AggregateRootBase<long>
    {
        public virtual int Length { get; protected set; }
        public virtual int Width { get; protected set; }
        public virtual int Height { get; protected set; }

        protected Product()
        {
        }

        public Product(long id, int length, int width, int height)
        {
            Id = id;
            Length = length;
            Width = width;
            Height = height;
        }
    }
}
