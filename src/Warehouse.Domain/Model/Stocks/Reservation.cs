using Framework.Domain;
using System;

namespace Warehouse.Domain.Model.Stocks
{
    public class Reservation : ValueObjectBase
    {
        public virtual long OrderId { get; protected set; }
        public virtual int CustomerId { get; protected set; }
        public virtual int ReservedCount { get; protected set; }
        public virtual DateTime ExpirationTime { get; protected set; }
        public bool Expired => DateTime.Now >= ExpirationTime;

        protected Reservation(){}

        public Reservation(long orderId, int customerId, int reserved)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ReservedCount = reserved;
            ExpirationTime = DateTime.Now.AddMinutes(30);
        }
    }
}
