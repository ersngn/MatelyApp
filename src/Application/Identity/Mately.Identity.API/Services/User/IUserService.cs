using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;
using Microsoft.AspNetCore.Identity;

namespace Mately.Identity.API.Services.User;

public interface IUserService
{
    Task<ApiTransactionResult<CheckUserResultDto>> IsExist(CheckUserDto checkUserDto);
    Task<ApiTransactionResult<CreateUserResultDto>> CreateAsync(ApplicationUser user);
    Task<ApiTransactionResult<UpdateUserResultDto>> UpdateAsync(ApplicationUser user);
    Task<ApiTransactionResult<ApplicationUser>> GetUserByUserName(GetUserByUserNameDto dto);
    Task<ApiTransactionResult<CheckPasswordResultDto>> CheckPassword(CheckPasswordDto dto);
    Task<ApiTransactionResult<List<GetUserRoleResultDto>>> GetUserRoles(string userId);
    Task<ApiTransactionResult<ApplicationUser>> GetById(string id);
}