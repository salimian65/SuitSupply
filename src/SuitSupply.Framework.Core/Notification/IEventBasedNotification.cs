using SuitSupply.Framework.Core.InternalEvents;

namespace SuitSupply.Framework.Core.Notification
{
    public interface IEventBasedNotification<out TEvent> : INotification where TEvent : IEnternalEvent
    {
        TEvent Event { get; }

        void SetEvent(dynamic @event);
    }
}