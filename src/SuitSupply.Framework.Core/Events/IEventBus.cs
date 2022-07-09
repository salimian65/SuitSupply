namespace SuitSupply.Framework.Core.Events
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void Unsubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
    }
}