using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sales.Interface.Facade.Contracts.Orders.Commands;
using Sales.Interface.Facade.Contracts.Orders.Services;

namespace Sales.Interface.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderFacadeService _facade;

        public OrdersController(IOrderFacadeService facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public long Post(CreateOrderCommand command)
        {
            Debug.WriteLine("Reached Api");
            return _facade.CreateOrder(command);
        }

        [HttpGet]
        public long Get()
        {
            return 1;
        }
    }
}
