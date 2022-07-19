using System;

namespace SuitSupply.Framework.MessageBroker
{
    public interface IExternalSubscriber
    {
        IAsyncMessageBrokerSubscription SubscribeAsync(string subscriptionDurableName,
                                                        string subject,
                                                        Action<StanMessage> action);

        IAsyncMessageBrokerSubscription SubscribeAsync(string subscriptionDurableName,
            string subject,
            string queueGroup,
            Action<StanMessage> action);

    }
}