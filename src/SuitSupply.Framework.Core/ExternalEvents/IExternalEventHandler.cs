namespace SuitSupply.Framework.Core.ExternalEvents
{
    public interface IExternalEventHandler<in TEvent> where TEvent : BaseExternalEvent<TEvent>
    {
        Task Handle(TEvent omsMessage);
    }
}


