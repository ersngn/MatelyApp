using Mately.Common.Domain.Dtos.Transaction;
using Mately.Indentity.API.Domain.AccountSecurity.Dtos;

namespace Mately.Indentity.API.Services.AccountSecurity;

public interface IAccountSecurityService
{
    Task<ApiTransactionResult<CreateAccountSecurityResultDto>> CreateAsync(
        Domain.Security.AccountSecurity accountSecurity);

    Task<ApiTransactionResult<GetAccountSecurityByAccountIdDto>> GetAccountSecurityByAccountId(Guid accountId);
}