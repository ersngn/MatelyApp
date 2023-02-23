using System.Linq.Expressions;
using Mately.Service.Match.Repository.MongoBase;
using Mately.Services.Match.Domain.Profile.Dtos;
using Mately.Services.Match.Domain.Profile.Model;

namespace Mately.Service.Match.Repository.Profile;

public interface IProfileRepository : IRepository<UserProfile>
{
    Task<List<UserProfile>> GetByDistanceAsync(GetProfileByDistanceDto filter);
    Task<long> ProfileCountByDistanceAsync(GetProfileByDistanceDto filter);
    
    Task<long> ProfileCountAsync();

}