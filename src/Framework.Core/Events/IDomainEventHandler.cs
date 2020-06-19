namespace Framework.Core.Events
{
    public interface IDomainEventHandler<T> where T : IEvent
    {
        void Handle(T domainEvent);
    }
}
