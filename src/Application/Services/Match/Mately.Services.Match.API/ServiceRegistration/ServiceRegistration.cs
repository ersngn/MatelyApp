using Mately.Core.Services.Uri;
using Mately.Service.Match.Repository.MongoBase;
using Mately.Service.Match.Repository.Profile;
using Mately.Services.Match.Business.Profile;

namespace Mately.Services.Match.API.ServiceRegistration;

public static class ServiceRegistration
{
    public static void AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        #region Serivces
        services.AddScoped<IProfileService, ProfileService>();
        #endregion

        #region Repositories
        services.AddScoped(typeof(IRepository<>),typeof(MongoRepository<>));
        services.AddScoped<IProfileRepository, ProfileRepository>();
        #endregion

        // #region Helper
        // services.AddScoped<IUriService, UriService>();
        // #endregion
    }
}