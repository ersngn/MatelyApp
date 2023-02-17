using Mately.Indentity.API.Repository.Base;

namespace Mately.Indentity.API.Repository.Account;

public interface IAccountRepository : IRepository<Domain.Account.Account>
{
    Task<Domain.Account.Account?> GetByUserNameAsync(string username);
}