using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Infrastructure;
using Mately.Identity.API.Repository.Base;

namespace Mately.Identity.API.Repository.User;

public class UserRepository : EfCoreRepository<ApplicationUser>,IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}