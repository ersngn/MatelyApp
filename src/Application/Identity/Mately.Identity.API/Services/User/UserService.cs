using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Repository.User;
using Mately.Identity.API.Services.SecurityKey;
using Mately.Indentity.API.Helpers.Security;
using Microsoft.AspNetCore.Identity;

namespace Mately.Identity.API.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserSecurityKeyService _userSecurityKeyService;
    private readonly ISecurityHelper _securityHelper;

    public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IMapper mapper, IUserSecurityKeyService userSecurityKeyService, ISecurityHelper securityHelper)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _mapper = mapper;
        _userSecurityKeyService = userSecurityKeyService;
        _securityHelper = securityHelper;
    }

    public async Task<ApiTransactionResult<CheckUserResultDto>> IsExist(CheckUserDto checkUserDto)
    {
        var response = new ApiTransactionResult<CheckUserResultDto>();
        try
        {
            var responseData = new CheckUserResultDto()
            {
                IsExist = true
            };

            var userByEmail = _userRepository.Get(e =>
                e.Email == checkUserDto.Email).ToList();
            
            if (userByEmail.Count > 0)
            {
                response.Fail(TransactionResultEnum.EmailAlreadyExist,responseData);
                return response;
            }
            
            var userByPhone = _userRepository.Get(e =>
                e.PhoneNumber == checkUserDto.Phone).ToList();
            
            if (userByPhone.Count > 0)
            {
                response.Fail(TransactionResultEnum.PhoneAlreadyExist,responseData);
                return response;
            }
            
            var userByUserName = _userRepository.Get(e =>
                e.UserName == checkUserDto.Username).ToList();
            
            if (userByUserName.Count > 0)
            {
                response.Fail(TransactionResultEnum.UserNameAlreadyExist,responseData);
                return response;
            }
            
            responseData.IsExist = false;
            response.Success(responseData);
            return response;
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }
    }

    public async Task<ApiTransactionResult<CreateUserResultDto>> CreateAsync(ApplicationUser user)
    {
        var response = new ApiTransactionResult<CreateUserResultDto>();

        try
        {
            var result = await _userRepository.AddAsync(user);
            var responseData = _mapper.Map<CreateUserResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<UpdateUserResultDto>> UpdateAsync(ApplicationUser user)
    {
        var response = new ApiTransactionResult<UpdateUserResultDto>();

        try
        {
            var result = await _userRepository.UpdateAsync(user);
            var responseData = _mapper.Map<UpdateUserResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<ApplicationUser>> GetUserByUserName(GetUserByUserNameDto dto)
    {
        var response = new ApiTransactionResult<ApplicationUser>();
        try
        {
            var result =  _userRepository.Get(e =>
                    e.UserName == dto.UserName || e.Email == dto.UserName || e.PhoneNumber == dto.UserName).Distinct()
                .FirstOrDefault();
            if (result==null)
            {
                response.Fail(TransactionResultEnum.UserNotFound);
                return response;
            }
            response.Success(result);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<CheckPasswordResultDto>> CheckPassword(CheckPasswordDto dto)
    {
        var response = new ApiTransactionResult<CheckPasswordResultDto>();
        try
        {
            var user = _userRepository.Get(e => e.Id == dto.Id).FirstOrDefault();
            if (user==null)
            {
                response.Fail(TransactionResultEnum.UserNotFound);
                return response;
            }

            var userSecurityKey = await _userSecurityKeyService.GetUserSecurityKeyByUserId(dto.Id);

            if (userSecurityKey.Data==null)
            {
                response.Fail(TransactionResultEnum.UserNotFound);
                return response;
            }

            //var salt = _securityHelper.CreateHash();
            var encryptKey = _securityHelper.CreateHash(dto.PasswordHash, userSecurityKey.Data.KeyValue);
 
            string getEncryptKey = encryptKey.HashedText.Split('æ')[0];
            string getSalt=encryptKey.HashedText.Split('æ')[1];
            
            var checkPasswordResult =
                _securityHelper.ValidateHash(dto.PasswordHash, userSecurityKey.Data.KeyValue, user.PasswordHash);
            if (!checkPasswordResult.isValidated)
            {
                response.Fail(TransactionResultEnum.PasswordNotMatch);
                return response;
            }
            
            response.Success(new CheckPasswordResultDto()
            {
                IsMatch = true
            });
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<List<GetUserRoleResultDto>>> GetUserRoles(string userId)
    {
        var response = new ApiTransactionResult<List<GetUserRoleResultDto>>();
        try
        {
            var user = GetById(userId).Result;
            if (!user.IsSuccess)
            {
                response.Fail(user.Messages);
                return response;
            }

            var userRoles = await _userManager.GetRolesAsync(user.Data);
            if (userRoles.Count<=0)
            {
                response.Fail(TransactionResultEnum.RolesNotFound);
                return response;
            }

            var responseData = new List<GetUserRoleResultDto>();
            
            foreach (var role in userRoles)
            {
                var roleDto = new GetUserRoleResultDto()
                {
                    Role = role
                };
                
                responseData.Add(roleDto);
            }
            
            response.Success(responseData);
            
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<ApplicationUser>> GetById(string id)
    {
        var response = new ApiTransactionResult<ApplicationUser>();
        try
        {
            var user = _userRepository.Get(e => e.Id == id).FirstOrDefault();
            if (user==null)
            {
                response.Fail(TransactionResultEnum.UserNotFound);
                return response;
            }
            
            response.Success(user);
            
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }
}