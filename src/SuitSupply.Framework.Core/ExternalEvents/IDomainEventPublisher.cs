using SuitSupply.Framework.Core.Outbox;

namespace SuitSupply.Framework.Core.ExternalEvents
{
    public interface IDomainEventPublisher
    {
        Task PublishAsync(OutboxItem outboxItem);
        Task PublishAsync(List<OutboxItem> outboxItems);
    }
}
