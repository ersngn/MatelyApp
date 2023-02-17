using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Infrastructure;
using Mately.Identity.API.Repository.Base;

namespace Mately.Identity.API.Repository.SecurityKey;

public class UserSecurityKeyRepository : EfCoreRepository<ApplicationUserSecurityKey>, IUserSecurityKeyRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserSecurityKeyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}