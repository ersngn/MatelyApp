using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.Auth.Dtos;

namespace Mately.Identity.API.Services.AuthService;

public interface IAuthService
{
    Task<ApiTransactionResult<RegisterResultDto>> Register(RegisterDto dto);
    Task<ApiTransactionResult<AdminRegisterResultDto>> AdminRegister(AdminRegisterDto dto);
    Task<ApiTransactionResult<LoginResultDto>> Login(LoginDto dto);
    Task<ApiTransactionResult<RefreshTokenResultDto>> RefreshToken(RefreshTokenDto dto);
}