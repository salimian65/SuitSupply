namespace SuitSupply.Framework.Core.InternalEvents
{
    public interface IEnternalEventBus
    {
        void Subscribe<TEvent>(IInternalEventHandler<TEvent> internalEventHandler) where TEvent : IEnternalEvent;

        void Unsubscribe<TEvent>(IInternalEventHandler<TEvent> internalEventHandler) where TEvent : IEnternalEvent;

        void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEnternalEvent;
    }
}