namespace SuitSupply.Framework.Core.ExternalEvents
{
    public interface IExternalEventPublisher
    {
        void Publish<T>(string subject, T messageHeader) where T : BaseEvent<T>;
    }
}