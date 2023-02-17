using System.Transactions;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Indentity.API.Domain.Account.Dtos;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;

namespace Mately.Indentity.API.Services.Account;

public interface IAccountService
{
    // Task<ApiTransactionResult<RegisterResultDto>> Register(RegisterDto dto);
    Task<ApiTransactionResult<CreateAccountResultDto>> CreateAsync(Domain.Account.Account account);
    Task<ApiTransactionResult<UpdateAccountResultDto>> UpdateAsync(Domain.Account.Account account);
    Task<ApiTransactionResult<GetAccountByFilterDto>> GetByUserName(string username);
}