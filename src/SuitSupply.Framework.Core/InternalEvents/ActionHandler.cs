namespace SuitSupply.Framework.Core.InternalEvents
{
    public class ActionHandler<TEvent> : IInternalEventHandler<TEvent> where TEvent : IEnternalEvent
    {
        private readonly Action<TEvent> handler;

        public ActionHandler(Action<TEvent> handlerDelegate)
        {
            handler = handlerDelegate;
        }

        public void Handle(TEvent eventToHandle)
        {
            handler(eventToHandle);
        }
    }
}