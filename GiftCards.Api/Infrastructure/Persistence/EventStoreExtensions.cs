
using GiftCards.Api.Domain.Repositories;

namespace GiftCards.Api.Infrastructure.Persistence;

public static class EventStoreExtensions
{
    public static void RegisterEventStore(this IServiceCollection services)
    {
        services.AddSingleton<EventStoreConnectionFactory>();
        services.AddScoped<IEventStore, EventStore>();
    }
}