using Dapper;
using GiftCards.Api.Domain;

namespace GiftCards.Api.Infrastructure.Persistence
{
    public class EventStore(EventStoreConnectionFactory dbConnectionFactory) : IEventStore
    {
        public IEnumerable<StoredEvent> GetEvents(Guid aggregateId)
        {
            const string query = """
                             SELECT [AggregateId], [SequenceNumber], [Timestamp]
                                   ,[EventTypeName], [EventBody], [RowVersion]
                             FROM dbo.[Events]
                             WHERE [AggregateId] = @AggregateId
                             ORDER BY [SequenceNumber]
                             """;

            using var connection = dbConnectionFactory.Create();

            return connection.Query<DatabaseEvent>(
                    query,
                    new { AggregateId = aggregateId })
                .Select(e => e.ToStoredEvent());
        }

        public IEnumerable<Guid> GetAllAggregateIds()
        {
            const string query = """
                             SELECT DISTINCT [AggregateId]
                             FROM dbo.[Events]
                             ORDER BY [AggregateId]
                             """;

            using var connection = dbConnectionFactory.Create();

            return connection.Query<Guid>(query);
        }

        private readonly List<StoredEvent> _newEvents = [];

        public void AppendEvent(StoredEvent @event)
        {
            _newEvents.Add(@event);
        }

        public void SaveChanges()
        {
            const string insertCommand = """
                                     INSERT INTO dbo.[Events]
                                                ([AggregateId], [SequenceNumber], [Timestamp]
                                                ,[EventTypeName], [EventBody])    
                                     VALUES
                                                (@AggregateId, @SequenceNumber,@Timestamp
                                                ,@EventTypeName, @EventBody)
                                     """;

            using var connection = dbConnectionFactory.Create();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            connection.Execute(
                insertCommand,
                _newEvents.Select(DatabaseEvent.FromStoredEvent),
                transaction);

            transaction.Commit();
            _newEvents.Clear();
        }
    }
}
