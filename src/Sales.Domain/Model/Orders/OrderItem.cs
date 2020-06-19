using Framework.Domain;
using Sales.Domain.Model.Products;
using System;

namespace Sales.Domain.Model.Orders
{
    public class OrderItem : ValueObjectBase
    {
        public virtual Product Product { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual bool IsReserved { get; protected set; }

        protected OrderItem() { }
        public OrderItem(Product product, int quantity, bool isReserved = false)
        {
            if (product == null)
                throw new Exception("The product does not exist!");

            Product = product;
            Quantity = quantity;
            IsReserved = isReserved;
        }

        public virtual OrderItem AddQuantity()
        {
            return new OrderItem(Product, Quantity + 1);
        }

        public virtual OrderItem DecreaseQuantity()
        {
            if (Quantity > 0)
                return new OrderItem(Product, Quantity - 1);
            return null;
        }

        public virtual OrderItem Reserve()
        {
            return new OrderItem(Product, Quantity, true);
        }
    }
}