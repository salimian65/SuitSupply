using SuitSupply.Framework.Core.CommandHandling;

namespace SuitSupply.Framework.Core.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent eventToHandle);
    }
}