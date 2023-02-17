using Mately.Core.Configs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mately.Services.Match.Infrastructure.MongoDbContext;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    public MongoDbContext(IOptions<MongoConfig> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DataBase);
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