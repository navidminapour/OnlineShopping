using System.Threading.Tasks;

namespace Framework.Core.Events
{
    public interface IIntegrationEventHandler<T> where T : IEvent
    {
        Task Handle(T @event);
    }
}
