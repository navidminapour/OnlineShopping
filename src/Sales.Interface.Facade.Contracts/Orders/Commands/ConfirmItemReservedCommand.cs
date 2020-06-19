using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Interface.Facade.Contracts.Orders.Commands
{
    public class ConfirmItemReservedCommand : Command
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }

        public ConfirmItemReservedCommand(long orderId, long productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
