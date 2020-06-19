using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;
using Warehouse.Interface.Facade.Contracts.Stocks.Services;

namespace Warehouse.Interface.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockFacadeService _facade;

        public StockController(IStockFacadeService facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public void Post(AddStockCommand command)
        {
            Debug.WriteLine("Reached Api");
            _facade.AddStock(command);
        }
    }
}
