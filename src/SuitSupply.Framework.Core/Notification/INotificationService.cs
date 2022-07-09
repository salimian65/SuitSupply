namespace SuitSupply.Framework.Core.Notification
{
    public interface INotificationService
    {
        Task SendAsync(INotification notification);

        void Queue(INotification notification);

        void SendAll();

        void FlushCache();
    }
}