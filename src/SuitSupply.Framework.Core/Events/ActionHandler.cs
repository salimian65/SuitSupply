using System;

namespace SuitSupply.Framework.Core.Events
{
    public class ActionHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
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