using Microsoft.Extensions.Logging;
using SuitSupply.Framework.Core.DependencyInjection;
using SuitSupply.Framework.Core.Notification;

namespace SuitSupply.Framework.Core.InternalEvents
{
    public class EnternalEventAggregator : IEnternalEventBus
    {
        private readonly INotificationService notificationService;

        private readonly ILogger logger;

        private readonly Queue<IBrokerMessage> brokerMessages = new Queue<IBrokerMessage>();

        public EnternalEventAggregator( INotificationService notificationService, ILogger logger)
        {
            this.logger = logger;
            this.notificationService = notificationService;
            Subscribers = new List<Subscriber>();
            Subscribe(new ActionHandler<TransactionCommitedEnternalEvent>(e =>
                                                                         {
                                                                             HandleTransactionCommited();
                                                                         }));
        }

        private IList<Subscriber> Subscribers { get; }

        public void Subscribe<TEvent>(IInternalEventHandler<TEvent> internalEventHandler) where TEvent : IEnternalEvent
        {
            Subscribers.Add(new Subscriber(internalEventHandler));
        }

     
        public void Unsubscribe<TEvent>(IInternalEventHandler<TEvent> internalEventHandler) where TEvent : IEnternalEvent
        {
            var subscriber = Subscribers.FirstOrDefault(e => e.Handler.Equals(internalEventHandler));
            if (subscriber != null)
            {
                Subscribers.Remove(subscriber);
            }
        }
        
        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEnternalEvent
        {
            var itemsToBeRemoved = new List<Subscriber>();
            HandleNotifications(eventToPublish);

            if (eventToPublish is IBrokerMessage)
            {
                brokerMessages.Enqueue(eventToPublish as IBrokerMessage);
                return;
            }

            var eligibleSubscribers = GetEligibleSubscribers<TEvent>();
            eligibleSubscribers.ForEach(s =>
                                        {
                                            Handle(s, eventToPublish);

                                            if (s.IsOneTime)
                                            {
                                                itemsToBeRemoved.Add(s);
                                            }
                                        });

            UnsubscribeItem(itemsToBeRemoved);
        }

        public void HandleTransactionCommited()
        {
            while (brokerMessages.Any())
            {
                var message = brokerMessages.Peek();
                Publish(message);
                brokerMessages.Dequeue();
            }
        }

        private static void SetNotificationData<TEvent>(INotification notification, TEvent @event) where TEvent : IEnternalEvent
        {
            var eventBasedNotification = notification as IEventBasedNotification<TEvent>;
            eventBasedNotification?.SetEvent(@event);
        }

        private List<Subscriber> GetEligibleSubscribers<TEvent>() where TEvent : IEnternalEvent
        {
            var subscribers = Subscribers.Where(s => s.Handler is IInternalEventHandler<TEvent>).ToList();

            var allResolvedHandlers = ServiceLocator.Current.ResolveAll<IInternalEventHandler<TEvent>>();
            var notSubscribeResolvedHandlers = allResolvedHandlers.Where(h => subscribers.All(s => s.Handler.GetType() != h.GetType())).ToList();
            subscribers.AddRange(notSubscribeResolvedHandlers.Select(handler => new Subscriber(handler)));

            return subscribers;
        }

        private void Handle<TEvent>(Subscriber subscriber, TEvent @event) where TEvent : IEnternalEvent
        {
            var handler = subscriber.Handler as IInternalEventHandler<TEvent>;
            handler?.Handle(@event);
            LogEvent(@event);
        }

        private void HandleNotifications(IEnternalEvent enternalEventToPublish)
        {
            var eventWithNotification = enternalEventToPublish as IWithNotificationEvent;
            if (eventWithNotification != null)
            {
                var notification = eventWithNotification.GetNotification();
                SetNotificationData(notification, enternalEventToPublish);
                notificationService.Queue(notification);
            }
        }

        private void UnsubscribeItem(IEnumerable<Subscriber> itemsToBeRemoved)
        {
            foreach (var item in itemsToBeRemoved)
            {
                Subscribers.Remove(item);
            }
        }

        private void LogEvent<TEvent>(TEvent eventToPublish)
        {
            logger.LogInformation(eventToPublish.ToString());
        }

        private class Subscriber
        {
            public Subscriber(object handler, bool isOneTime = false)
            {
                Handler = handler;
                IsOneTime = isOneTime;
            }

            public object Handler { get; }

            public bool IsOneTime { get; }
        }
    }
}