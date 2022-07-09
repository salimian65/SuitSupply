namespace SuitSupply.Framework.Core.Notification
{
    public abstract class EventBasedNotification<TEvent>
    {
        public TEvent Event { get; private set; }

        public abstract int NotificationId { get; }

        public abstract string GetMessage(string templateMessage, Recipient recipient);

        public abstract Recipient GetRecipient();

        public void SetEvent(dynamic @event)
        {
            Event = @event;
        }
    }
}