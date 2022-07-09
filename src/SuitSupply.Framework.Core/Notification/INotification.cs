namespace SuitSupply.Framework.Core.Notification
{
    public interface INotification
    {
        int NotificationId { get; }

        string GetMessage(string templateMessage, Recipient recipient);

        Recipient GetRecipient();
    }
}