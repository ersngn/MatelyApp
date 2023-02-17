using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;

namespace Mately.Identity.API.Services.SecurityKey;

public interface IUserSecurityKeyService
{
    Task<ApiTransactionResult<CreateSecurityKeyResultDto>> CreateAsync(
        ApplicationUserSecurityKey securityKey);
    
    Task<ApiTransactionResult<GetSecurityKeyByUserIdResultDto>> GetUserSecurityKeyByUserId(string userId);
}