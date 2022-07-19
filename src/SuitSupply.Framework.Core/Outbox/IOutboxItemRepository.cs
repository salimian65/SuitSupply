namespace SuitSupply.Framework.Core.Outbox
{
    public interface IOutboxItemRepository
    {
        Task<List<OutboxItem>> GetAllEventsThatHaveNotBeenSentAsync();

        Task MarkTheseItemsAsSentAsync(List<OutboxItem> outboxItems);
    }
}
