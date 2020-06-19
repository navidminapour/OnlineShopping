using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Services
{
    public interface IOrderService
    {
        bool HasAnyPendingOrders(long customerId);
    }
}
