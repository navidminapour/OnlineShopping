using Framework.Application;
using Framework.Core;
using Framework.Core.Events;
using Framework.NH;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Config
{
    public class Bootstrapper
    {
        public static void WireUp(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMqBus>();

            services.AddSingleton<ICommandBus, CommandBus>();

            services.AddScoped<IUnitOfWork, NHUnitOfWork>();
        }
    }
}
