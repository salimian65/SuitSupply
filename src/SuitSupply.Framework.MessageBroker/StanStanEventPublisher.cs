using STAN.Client;
using SuitSupply.Framework.Core.ExternalEvents;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanExternalEventPublisher : IExternalEventPublisher
    {
        private readonly IStanConnection _stanConnection;

        public StanExternalEventPublisher(IStanConnection stanConnection)
        {
            _stanConnection = stanConnection;
        }

        public void Publish<T>(string subject, T domainEvent) where T : BaseEvent<T>
        {
            _stanConnection.Publish(subject, domainEvent.SerializeObject(domainEvent));
        }
    }
}