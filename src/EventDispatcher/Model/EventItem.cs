using System;

namespace EventsDispatcher.Model
{
    public class EventItem
    {
        public Guid Id { get; set; }
        public string EventType { get; set; }
        public string SerializedContent { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
