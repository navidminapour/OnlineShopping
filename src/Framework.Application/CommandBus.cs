using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CommandBus(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task Dispatch<T>(T command) where T : Command
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            return mediator.Send(command);
        }
    }
}
