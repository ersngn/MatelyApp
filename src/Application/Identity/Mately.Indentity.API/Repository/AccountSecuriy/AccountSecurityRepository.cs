using Mately.Indentity.API.Domain.Security;
using Mately.Indentity.API.Infrastructure;
using Mately.Indentity.API.Repository.Base;

namespace Mately.Indentity.API.Repository.AccountSecuriy;

public class AccountSecurityRepository : EfCoreRepository<AccountSecurity>,IAccountSecurityRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AccountSecurityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}