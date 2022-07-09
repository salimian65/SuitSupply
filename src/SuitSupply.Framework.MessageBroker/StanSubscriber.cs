using System;
using STAN.Client;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanSubscriber : IStanSubscriber
    {
        private readonly IStanConnection _connection;
       
        public StanSubscriber(IStanConnection connection)
        {
           this._connection = connection;
        }

        public IAsyncMessageBrokerSubscription SubscribeAsync(string subscriptionId,
            string subject,
            Action<StanMessage> action)
        {
            var subscriptionOptions = StanSubscriptionOptions.GetDefaultOptions();
            subscriptionOptions.DurableName = subscriptionId;
            subscriptionOptions.ManualAcks = true;

            return new StanAsyncMessageBrokerSubscription(
                _connection.Subscribe(
                    subject,
                    subscriptionOptions,
                    (s, args) =>
                    {
                        action(
                            new StanMessage
                            {
                                Subject = args.Message.Subject,
                                Body = args.Message.Data,
                                StanMsg  = args.Message
                            }
                        );
                    }
                ));
        }

        public IAsyncMessageBrokerSubscription SubscribeAsync(string subscriptionId,
            string subject,
            string queueGroup,
            Action<StanMessage> action)
        {
            var subscriptionOptions = StanSubscriptionOptions.GetDefaultOptions();
            subscriptionOptions.DurableName = subscriptionId;
            subscriptionOptions.ManualAcks = true;


            return new StanAsyncMessageBrokerSubscription(
                _connection.Subscribe(
                    subject,
                    queueGroup,
                    subscriptionOptions,
                    (s, args) =>
                    {
                        action(
                            new StanMessage
                            {
                                Subject = args.Message.Subject,
                                Body = args.Message.Data,
                                StanMsg = args.Message
                            }
                        );
                    }
                ));
        }
    }

    public interface IAsyncMessageBrokerSubscription
    {
    }
}