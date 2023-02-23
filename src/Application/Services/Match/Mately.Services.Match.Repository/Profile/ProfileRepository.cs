using System.Linq.Expressions;
using Mately.Core.Configs;
using Mately.Service.Match.Repository.MongoBase;
using Mately.Services.Match.Domain.Profile.Dtos;
using Mately.Services.Match.Domain.Profile.Model;
using Mately.Services.Match.Infrastructure.MongoDbContext;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mately.Service.Match.Repository.Profile;

public class ProfileRepository : MongoRepository<UserProfile>, IProfileRepository
{
    private readonly IMongoCollection<UserProfile> _collection;
    
    public ProfileRepository(IMongoConfig mongoConfig) : base(mongoConfig)
    {
        var dbContext = new MongoDbContext(mongoConfig);
        _collection = dbContext.GetCollection<UserProfile>();
    }

    public async Task<List<UserProfile>> GetByDistanceAsync(GetProfileByDistanceDto filter)
    {
        return await _collection.Find(e =>
                e.isActive == true && e.isDeleted == false &&
                Math.Abs((int)(e.Location.Lat - filter.Lat)) < (int)filter.Distance &&
                Math.Abs((int)(e.Location.Lon - filter.Lon)) < (int)filter.Distance)
            .Skip((filter.PageNumber - 1) * filter.PageSize).Limit(filter.PageSize).ToListAsync();
    }

    public async Task<long> ProfileCountByDistanceAsync(GetProfileByDistanceDto filter)
    {
        return await _collection.Find(e =>
                e.isActive == true && e.isDeleted == false &&
                Math.Abs((int)(e.Location.Lat - filter.Lat)) < (int)filter.Distance &&
                Math.Abs((int)(e.Location.Lon - filter.Lon)) < (int)filter.Distance)
            .CountDocumentsAsync();
    }

    public async Task<long> ProfileCountAsync()
    {
        return await _collection.CountDocumentsAsync(new BsonDocument());
    }
}