using Framework.NH;
using Sales.Interface.Facade;
using Sales.Persistence.NH.Mappings;
using Sales.Persistence.NH.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Framework.Application;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Services;
using Sales.Domain.Model.Orders;
using Sales.Interface.Facade.Contracts.Orders.Commands;
using Sales.Interface.Facade.Contracts.Orders.Services;
using MediatR;
using Framework.Core.Events;
using NHibernate;
using Sales.Application.CommandHandlers;
using Sales.Domain.Model.Categories;
using Sales.Domain.Model.Products;
using Warehouse.Domain.Contracts.Stocks.Events;
using Sales.Interface.RabbitMq;

namespace Sales.Config
{
    public class Bootstrapper
    {
        public static void WireUp(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("SalesDbConnection");
            
            var sessionFactory = SessionFactoryBuilder.CreateByConnectionString(connectionString, typeof(OrderMapping).Assembly);

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

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();
            services.AddTransient<IRequestHandler<ConfirmItemReservedCommand, bool>, ConfirmItemReservedCommandHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));

            services.AddMediatR(typeof(CreateOrderCommandHandler));

            services.AddTransient<IOrderFacadeService, OrderFacadeService>();

            //services.AddTransient<IEventHandler<ProductReserved>, ProductReservedHandler>();
            //services.AddTransient<IEventHandler<ProductReserveRejected>, ProductReserveRejectedHandler>();

            //Subscriptions
            services.AddTransient<ProductReservedHandler>();
            services.AddTransient<ProductReserveRejectedHandler>();


            ConfigureEventBus(services);
        }

        private static void ConfigureEventBus(IServiceCollection services)
        {
            var eventBus = services.BuildServiceProvider().GetRequiredService<IEventBus>();
            eventBus.Subscribe<ProductReserved, ProductReservedHandler>();
            eventBus.Subscribe<ProductReserveRejected, ProductReserveRejectedHandler>();
        }
    }
}
