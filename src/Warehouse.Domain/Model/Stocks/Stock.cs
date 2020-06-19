using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Contracts.Stocks.Events;
using Warehouse.Domain.Model.Products;

namespace Warehouse.Domain.Model.Stocks
{
    public class Stock : AggregateRootBase<long>
    {
        public virtual Product Product { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual IList<Reservation> Reservations { get; protected set; } = new List<Reservation>();

        protected Stock(){}

        public Stock(long id, Product product, int quantity)
        {
            if (Product == null)
                throw new Exception("The product does not exist!");

            Id = id;
            Product = product;
            Quantity = quantity;
        }

        protected virtual int GetAvailableQuantity()
        {
            return Quantity - GetAllReserved();
        }

        protected virtual int GetAllReserved()
        {
            return Reservations?.Where(x => !x.Expired).Sum(x => x.ReservedCount) ?? 0;
        }

        public virtual void Reserve(long orderId, int customerId, int requestedCount)
        {
            var customerReservation = Reservations.FirstOrDefault(x => x.CustomerId == customerId && !x.Expired);
            int availableQuantity = GetAvailableQuantity();

            if (customerReservation == null && availableQuantity >= requestedCount)
            {
                Reservations.Add(new Reservation(orderId, customerId, requestedCount));
            }
            else if(customerReservation != null && availableQuantity + customerReservation.ReservedCount >= requestedCount)
            {
                var index = Reservations.IndexOf(customerReservation);
                if (index != -1)
                    Reservations[index] = new Reservation(orderId, customerId, requestedCount);
            }
            else
            {
                AddDomainEvent(new ProductReserveRejected(orderId, customerId, Product.Id, requestedCount, availableQuantity));
                return;
            }
            AddDomainEvent(new ProductReserved(orderId, customerId, Product.Id, requestedCount));
        }
    }
}