using Mately.Common.Domain.Dtos.Transaction;
using Mately.Indentity.API.Domain.User.Dtos;

namespace Mately.Indentity.API.Services.User;

public interface IUserService
{
    Task<ApiTransactionResult<CreateUserResultDto>> CreateAsync(Domain.User.User user);
    Task<ApiTransactionResult<CheckUserResultDto>> IsExist(string email, string phone, string username);
}