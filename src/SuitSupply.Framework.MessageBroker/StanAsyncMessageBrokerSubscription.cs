using STAN.Client;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanAsyncMessageBrokerSubscription : IAsyncMessageBrokerSubscription
    {
        private readonly IStanSubscription _subscription;

        public StanAsyncMessageBrokerSubscription(IStanSubscription subscription)
        {
            _subscription = subscription;
        }

        public void Dispose()
        {
            _subscription.Close(); // for maintaining durable interests
        }
    }
}