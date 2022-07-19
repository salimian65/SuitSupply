using SuitSupply.Framework.Core.ExternalEvents;
using SuitSupply.Framework.MessageBroker;
using SuitSupply.Tailoring.Interface.InboxListener.Handlers;
using SuitSupply.Tailoring.Interface.InboxListener.Models;

namespace SuitSupply.Tailoring.Interface.InboxListener.Subscribers
{
    public class Subscriber : ISubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Subscriber> _logger;
        private readonly IExternalSubscriber _externalSubscriber;
        private readonly StanQueueGroupName _queueGroup;
        public Subscriber(ILogger<Subscriber> logger,
            IExternalSubscriber externalSubscriber,
            StanQueueGroupName queueGroup,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _externalSubscriber = externalSubscriber;
            _queueGroup = queueGroup;
            _serviceProvider = serviceProvider;
        }

        public void Subscribe()
        {
            _externalSubscriber.SubscribeAsync("DurableNameOrderPaidEvent",
               "OrderPaidEnternalEvent",
                _queueGroup.Name,
               OnReceivedOrderPaidMessage);

            _logger.Log(LogLevel.Information, "Stan Subscription in SuitSupply messages has been done");
        }

        private void OnReceivedOrderPaidMessage(StanMessage args)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetService<OrderPaidEventHandler>();
                var orderPaidEvent = OrderPaidEvent.DeserializeObject(args.Body);

                handler.Handle(orderPaidEvent).Wait();
                args.StanMsg.Ack();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }
    }
}