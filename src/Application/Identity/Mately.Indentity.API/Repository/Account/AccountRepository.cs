using Mately.Indentity.API.Infrastructure;
using Mately.Indentity.API.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Mately.Indentity.API.Repository.Account;

public class AccountRepository : EfCoreRepository<Domain.Account.Account>, IAccountRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public AccountRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Domain.Account.Account?> GetByUserNameAsync(string username)
    {
        var account = await _applicationDbContext.Accounts
            .Where(e => e.User.Email == username || e.User.UserName == username || e.User.PhoneNumber == username)
            .FirstOrDefaultAsync();

        return account;
    }
}