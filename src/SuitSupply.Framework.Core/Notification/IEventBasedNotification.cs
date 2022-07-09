using SuitSupply.Framework.Core.Events;

namespace SuitSupply.Framework.Core.Notification
{
    public interface IEventBasedNotification<out TEvent> : INotification where TEvent : IEvent
    {
        TEvent Event { get; }

        void SetEvent(dynamic @event);
    }
}