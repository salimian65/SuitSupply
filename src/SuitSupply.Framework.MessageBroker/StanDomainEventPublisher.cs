using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using STAN.Client;
using SuitSupply.Framework.Core.ExternalEvents;
using SuitSupply.Framework.Core.Outbox;

namespace SuitSupply.Framework.MessageBroker
{
    public class StanDomainEventPublisher : IDomainEventPublisher
    {
        private readonly IStanConnection _stanConnection;
        private readonly ILogger<StanDomainEventPublisher> _logger;

        public StanDomainEventPublisher(StanConnectionFactory stanConnectionFactory, ILogger<StanDomainEventPublisher> logger)
        {
            _logger = logger;
            _stanConnection = stanConnectionFactory.Create();
        }

        public async Task PublishAsync(OutboxItem outboxItem)
        {
            await _stanConnection.PublishAsync(outboxItem.Type, Encoding.UTF8.GetBytes(outboxItem.Body));
            _logger.LogDebug($"Subject: {outboxItem.Type}, Event Id: {outboxItem.EventId} published.");
        }

        public async Task PublishAsync(List<OutboxItem> outboxItems)
        {
            foreach (var outboxItem in outboxItems)
                await PublishAsync(outboxItem);
        }
    }
}
