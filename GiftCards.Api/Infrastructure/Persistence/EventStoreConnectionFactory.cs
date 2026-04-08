using Microsoft.Data.SqlClient;
using System.Data;

namespace GiftCards.Api.Infrastructure.Persistence;

public class EventStoreConnectionFactory(IConfiguration configuration)
{
    private readonly string? _connectionString
        = configuration.GetConnectionString("EventStore");

    public IDbConnection Create()
        => new SqlConnection(_connectionString);
}