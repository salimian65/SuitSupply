using System.Data.SqlClient;
using Dapper;
using SuitSupply.Framework.Core.Outbox;

namespace SuitSupply.Tailoring.Infrastructure.OutboxItemRepository
{
    public class OutboxItemRepository : IOutboxItemRepository
    {
        private readonly string _connectionString;

        public OutboxItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<OutboxItem>> GetAllEventsThatHaveNotBeenSentAsync()
        {
            await using var db = new SqlConnection(_connectionString);
            var outboxItems = await db.QueryAsync<OutboxItem>(Resources.SelectDomainEvents);
            return outboxItems.ToList();
        }

        public async Task MarkTheseItemsAsSentAsync(List<OutboxItem> outboxItems)
        {
            if (outboxItems?.Count > 0)
            {
                var ids = outboxItems.Select(i => i.Id);
                await using var db = new SqlConnection(_connectionString);
                await db.ExecuteAsync(Resources.UpdateDomainEventsIsSend, new {Ids = ids});
            }
        }
    }
}
