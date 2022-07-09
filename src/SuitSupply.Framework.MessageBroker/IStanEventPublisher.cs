namespace SuitSupply.Framework.MessageBroker
{
    public interface IEventPublisher
    {
        void Publish<T>(string subject, T messageHeader) where T : BaseEvent<T>;
    }
}