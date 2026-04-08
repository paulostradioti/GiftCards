namespace GiftCards.Api.Domain;

public interface IEventStore
{
    IEnumerable<StoredEvent> GetEvents(Guid aggregateId);
    IEnumerable<Guid> GetAllAggregateIds();
    void AppendEvent(StoredEvent @event);
    void SaveChanges();
}