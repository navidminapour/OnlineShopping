using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Events
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : IEvent;
        void Subscribe<T,TH>() where T : IEvent where TH : IEventHandler<T>;
    }
}
