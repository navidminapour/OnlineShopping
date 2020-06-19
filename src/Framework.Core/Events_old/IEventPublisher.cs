using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
