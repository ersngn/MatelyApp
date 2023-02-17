using Mately.Indentity.API.Infrastructure;
using Mately.Indentity.API.Repository.Base;

namespace Mately.Indentity.API.Repository.User;

public class UserRepository : EfCoreRepository<Domain.User.User>,IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}