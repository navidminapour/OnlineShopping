using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Events;
using Framework.Domain;
using Sales.Domain.Contracts.Orders.Events;
using Sales.Domain.Model.Products;
using Sales.Domain.Services;

namespace Sales.Domain.Model.Orders
{
    public class Order : AggregateRootBase<long>
    {
        public virtual int CustomerId { get; protected set; }
        public virtual OrderState OrderState { get; protected set; }
        public virtual IList<OrderItem> Items { get; protected set; }

        protected Order() { }

        public Order(long id, int customerId, IList<OrderItem> items, IOrderService orderService)
        {
            if (items == null || !items.Any())
                throw new Exception("No items were chosen!");

            if (customerId <= 0)
                throw new Exception("Customer is not specified!");

            if (orderService.HasAnyPendingOrders(customerId))
                throw new Exception("There is already an order in your basket!");

            if (IsThereAnySameItem(items)) 
                throw new Exception("There are some same item in your order!");

            Id = id;
            Items = items;
            CustomerId = customerId;
            OrderState = OrderState.Placed;

            AddDomainEvent(new OrderPlaced(Id, CustomerId,
                Items.Select(x => new OrderPlacedItem(x.Product.Id, x.Quantity)).ToList()));
        }

        public virtual void ConfirmReservedItem(long productId)
        {
            var currentItem = Items.FirstOrDefault(x => x.Product.Id == productId);
            if (currentItem == null)
                throw new Exception("The product does not exist in your order!");

            var index = Items.IndexOf(currentItem);
            if(index != -1)
                Items[index] = currentItem.Reserve();

            if(Items.All(x => x.IsReserved))
            {
                OrderState = OrderState.Reserved;
                AddDomainEvent(new AllOrderItemsReserved(Id, CustomerId));
            }  
        }

        private bool IsThereAnySameItem(IList<OrderItem> items)
        {
            return items.Count != items.Select(x => x.Product.Id).Distinct().Count();   
        }
    }
}
