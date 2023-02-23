using Mately.Core.Configs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mately.Services.Match.Infrastructure.MongoDbContext;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext(IMongoConfig config)
    {
        var client = new MongoClient(config.ConnectionString);
        _database = client.GetDatabase(config.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return _database.GetCollection<T>(typeof(T).Name.Trim());
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}