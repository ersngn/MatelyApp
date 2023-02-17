using Mately.Common.Domain.Dtos.Transaction;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;

namespace Mately.Indentity.API.Services.Auth;

public interface IAuthService
{
    Task<ApiTransactionResult<RegisterResultDto>> Register(RegisterDto dto);
    Task<ApiTransactionResult<LoginResultDto>> Login(LoginDto dto);
}