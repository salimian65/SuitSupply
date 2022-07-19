namespace SuitSupply.Framework.Core.InternalEvents
{
    public interface IInternalEventHandler<in TEvent> where TEvent : IEnternalEvent
    {
        void Handle(TEvent eventToHandle);
    }
}