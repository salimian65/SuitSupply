using STAN.Client;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanEventPublisher : IEventPublisher
    {
        private readonly IStanConnection _stanConnection;

        public StanEventPublisher(IStanConnection stanConnection)
        {
            _stanConnection = stanConnection;
        }

        public void Publish<T>(string subject, T domainEvent) where T : BaseEvent<T>
        {
            _stanConnection.Publish(subject, domainEvent.SerializeObject(domainEvent));
        }
    }
}