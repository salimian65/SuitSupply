using Microsoft.Extensions.Logging;
using SuitSupply.Framework.Core.Notification;

namespace SuitSupply.Framework.Core.Events
{
    public class EventAggregator : IEventBus
    {
        private readonly INotificationService notificationService;

        private readonly ILogger logger;

        private readonly Queue<IBrokerMessage> brokerMessages = new Queue<IBrokerMessage>();

        public EventAggregator( INotificationService notificationService, ILogger logger)
        {
            this.logger = logger;
            this.notificationService = notificationService;
            Subscribers = new List<Subscriber>();
            Subscribe(new ActionHandler<TransactionCommitedEvent>(e =>
                                                                         {
                                                                             HandleTransactionCommited();
                                                                         }));
        }

        private IList<Subscriber> Subscribers { get; }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            Subscribers.Add(new Subscriber(eventHandler));
        }

     
        public void Unsubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            var subscriber = Subscribers.FirstOrDefault(e => e.Handler.Equals(eventHandler));
            if (subscriber != null)
            {
                Subscribers.Remove(subscriber);
            }
        }
        
        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
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

        private static void SetNotificationData<TEvent>(INotification notification, TEvent @event) where TEvent : IEvent
        {
            var eventBasedNotification = notification as IEventBasedNotification<TEvent>;
            eventBasedNotification?.SetEvent(@event);
        }

        private List<Subscriber> GetEligibleSubscribers<TEvent>() where TEvent : IEvent
        {
            var subscribers = Subscribers.Where(s => s.Handler is IEventHandler<TEvent>).ToList();

            var allResolvedHandlers = ServiceLocator.Current.ResolveAll<IEventHandler<TEvent>>();
            var notSubscribeResolvedHandlers = allResolvedHandlers.Where(h => subscribers.All(s => s.Handler.GetType() != h.GetType())).ToList();
            subscribers.AddRange(notSubscribeResolvedHandlers.Select(handler => new Subscriber(handler)));

            return subscribers;
        }

        private void Handle<TEvent>(Subscriber subscriber, TEvent @event) where TEvent : IEvent
        {
            var handler = subscriber.Handler as IEventHandler<TEvent>;
            handler?.Handle(@event);
            LogEvent(@event);
        }

        private void HandleNotifications(IEvent eventToPublish)
        {
            var eventWithNotification = eventToPublish as IWithNotificationEvent;
            if (eventWithNotification != null)
            {
                var notification = eventWithNotification.GetNotification();
                SetNotificationData(notification, eventToPublish);
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