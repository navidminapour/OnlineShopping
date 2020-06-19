using Framework.Core.Events;
using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyList<DomainEvent> DomainEvents { get; }
        void ClearEvents();
    }
}