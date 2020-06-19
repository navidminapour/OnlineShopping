using System;

namespace Framework.Core.Events
{
    public class DomainEvent : IEvent
    {
        public Guid EventId { get; private set; }
        public DateTime PublishDateTime { get; private set; }
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.PublishDateTime = DateTime.Now;
        }
    }
}
