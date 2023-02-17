using Mately.Identity.API.Repository.Base;
using Mately.Identity.API.Repository.Device;
using Mately.Identity.API.Repository.SecurityKey;
using Mately.Identity.API.Repository.User;
using Mately.Identity.API.Services.AuthService;
using Mately.Identity.API.Services.Device;
using Mately.Identity.API.Services.SecurityKey;
using Mately.Identity.API.Services.User;
using Mately.Indentity.API.Helpers.Security;

namespace Mately.Identity.API.Helpers.ServiceCollection;

public static class ServiceCollectionHelper
{
    public static void AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSecurityKeyService, UserSecurityKeyService>();
        services.AddScoped<IUserDeviceService, UserDeviceService>();
        services.AddScoped<IAuthService, AuthService>();
        #endregion

        #region Repositories
        services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDeviceRepository, UserDeviceRepository>();
        services.AddScoped<IUserSecurityKeyRepository, UserSecurityKeyRepository>();
        #endregion

        #region Helper
        services.AddScoped<ISecurityHelper, SecurityHelper>();
        #endregion
    }
}