using System.Collections.Generic;
using System.Diagnostics;
using Framework.Core.Events;

namespace Framework.Domain
{
    public class AggregateRootBase<T> : EntityBase<T> , IAggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
        public virtual IReadOnlyList<DomainEvent> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(DomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
