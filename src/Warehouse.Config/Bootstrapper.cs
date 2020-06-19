using Framework.Application;
using Framework.Core.Events;
using Framework.NH;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Contracts.Orders.Events;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using NHibernate;
using Warehouse.Application.CommandHandlers;
using Warehouse.Domain.Contracts.Stocks.Events;
using Warehouse.Domain.Model.Stocks;
using Warehouse.Interface.Facade;
using Warehouse.Interface.Facade.Contracts.Stocks.Commands;
using Warehouse.Interface.Facade.Contracts.Stocks.Services;
using Warehouse.Interface.RabbitMq;
using Warehouse.Persistence.NH;
using Warehouse.Persistence.NH.Repositories;

namespace Warehouse.Config
{
    public class Bootstrapper
    {
        public static void WireUp(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("WarehouseDbConnection");

            var sessionFactory = SessionFactoryBuilder.CreateByConnectionString(connectionString, typeof(StockMapping).Assembly);

            services.AddScoped<IDbConnection>(f =>
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            services.AddScoped<ISession>(f =>
            {
                var connection = f.CreateScope().ServiceProvider.GetService<IDbConnection>() as DbConnection;
                var session = sessionFactory.WithOptions().Connection(connection).OpenSession();
                return session;
            });

            services.AddTransient<IStockRepository, StockRepository>();

            services.AddTransient<IRequestHandler<ReserveOrderCommand, bool>, ReserveOrderCommandHandler>();
            services.AddTransient<IRequestHandler<AddStockCommand, bool>, AddStockCommandHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));

            services.AddMediatR(typeof(ReserveOrderCommandHandler));

            services.AddScoped<IStockFacadeService, StockFacadeService>();

            //services.AddTransient<IEventHandler<OrderPlaced>, OrderPlacedHandler>();
            services.AddTransient<OrderPlacedHandler>();

            ConfigureEventBus(services);
        }

        private static void ConfigureEventBus(IServiceCollection services)
        {
            var eventBus = services.BuildServiceProvider().GetRequiredService<IEventBus>();
            eventBus.Subscribe<OrderPlaced, OrderPlacedHandler>();
        }
    }
}
