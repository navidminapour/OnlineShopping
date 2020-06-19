namespace Framework.Core.Events
{
    public interface IEventListener
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
        void Unsubcribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}
