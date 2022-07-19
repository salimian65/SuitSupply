using SuitSupply.Framework.Core.ExternalEvents;
using SuitSupply.Framework.Core.Outbox;
using SuitSupply.Framework.MessageBroker;

namespace SuitSupply.Tailoring.Interface.OutboxPublisher
{

    public class OutboxWorker : BackgroundService
    {
        private readonly ILogger<OutboxWorker> _logger;
        private readonly IOutboxItemRepository _outboxItemRepository;
        private readonly IDomainEventPublisher _domainEventPublisher;


        public OutboxWorker(IOutboxItemRepository outboxItemRepository, IDomainEventPublisher domainEventPublisher, ILogger<OutboxWorker> logger)
        {
            _outboxItemRepository = outboxItemRepository;
            _domainEventPublisher = domainEventPublisher;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var outboxItems = await _outboxItemRepository.GetAllEventsThatHaveNotBeenSentAsync();
                    _logger.LogDebug($"************ {outboxItems.Count} events selected to publish. ************");
                    await _domainEventPublisher.PublishAsync(outboxItems);

                    await _outboxItemRepository.MarkTheseItemsAsSentAsync(outboxItems);
                    _logger.LogDebug($"************ {outboxItems.Count} events marked as published. ************");

                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                    throw;
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}