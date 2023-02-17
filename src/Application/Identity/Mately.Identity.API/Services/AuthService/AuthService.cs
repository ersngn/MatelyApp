using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Identity.API.Domain.Auth.Dtos;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Helpers.Token;
using Mately.Identity.API.Helpers.Validation;
using Mately.Identity.API.Services.AuthService.Validation;
using Mately.Identity.API.Services.SecurityKey;
using Mately.Identity.API.Services.User;
using Mately.Indentity.API.Helpers.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Extensions;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Mately.Identity.API.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly ISecurityHelper _securityHelper;
    private readonly IUserSecurityKeyService _userSecurityKeyService;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IMapper mapper, IUserService userService, ISecurityHelper securityHelper,
        IUserSecurityKeyService userSecurityKeyService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
        _userService = userService;
        _securityHelper = securityHelper;
        _userSecurityKeyService = userSecurityKeyService;
    }

    public async Task<ApiTransactionResult<RegisterResultDto>> Register(RegisterDto dto)
    {
        #region Validation

        var response = new ApiTransactionResult<RegisterResultDto>();
        var validator = new ValidatorRegisterDto();
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            response.Fail(ValidationHelper.ErrorValidation(validationResult));
            return response;
        }
        #endregion

        try
        {
            var userIsexist = _userService.IsExist(new CheckUserDto()
                { Email = dto.Email, Phone = dto.PhoneNumber, Username = dto.UserName }).Result;
            if (!userIsexist.IsSuccess)
            {
                response.Fail(userIsexist.Messages);
                return response;
            }


            var user = _mapper.Map<ApplicationUser>(dto);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            user.FullName = dto.FirstName + " " + dto.LastName;
            user.IsActive = true;
            user.İsDeleted = false;
            user.SubscriptionType = SubscriptionType.Free;
            user.Id = user.SecurityStamp;
            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;
            user.AccessFailedCount = 0;
            user.TwoFactorEnabled = false;
            var userCreateResult = await _userService.CreateAsync(user);
            if (!userCreateResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.UserNotCreated);
                return response;
            }

            var applicationUserSecurityKey = new ApplicationUserSecurityKey()
            {
                Id = Guid.NewGuid(),
                UserId = userCreateResult.Data.Id,
                KeyValue = _securityHelper.CreateHash().HashedText,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };
            var accountSecurityCreatedResult = await _userSecurityKeyService.CreateAsync(applicationUserSecurityKey);
            if (!accountSecurityCreatedResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountSecurityNotCreated);
                return response;
            }

            user.PasswordHash = _securityHelper.CreateHash(dto.Password, accountSecurityCreatedResult.Data.KeyValue)
                .HashedText;

            user.UpdatedDate = DateTime.Now;
            var userUpdateResult = await _userService.UpdateAsync(user);
            if (!userUpdateResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountNotUpdated);
                return response;
            }
            
            if (!await _roleManager.RoleExistsAsync(AccountRole.FreeUser.GetDisplayName()))
                await _roleManager.CreateAsync(new IdentityRole(AccountRole.FreeUser.GetDisplayName()));
            if (await _roleManager.RoleExistsAsync(AccountRole.FreeUser.GetDisplayName()))
                await _userManager.AddToRoleAsync(user, AccountRole.FreeUser.GetDisplayName());

            var registerResult = _mapper.Map<RegisterResultDto>(userUpdateResult.Data);
            response.Success(registerResult);
        }
        catch (Exception e)
        {       
            response.UnKnownError(e.Message);
            return response;
        }
        return response;
    }

    public async Task<ApiTransactionResult<AdminRegisterResultDto>> AdminRegister(AdminRegisterDto dto)
    {
        #region Validation

        var response = new ApiTransactionResult<AdminRegisterResultDto>();
        var validator = new ValidationAdminRegisterDto();
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            response.Fail(ValidationHelper.ErrorValidation(validationResult));
            return response;
        }
        #endregion

        try
        {
            var userIsexist = _userService.IsExist(new CheckUserDto()
                { Email = dto.Email, Phone = dto.PhoneNumber, Username = dto.UserName }).Result;
            if (!userIsexist.IsSuccess)
            {
                response.Fail(userIsexist.Messages);
                return response;
            }
            
            var user = _mapper.Map<ApplicationUser>(dto);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            user.FullName = dto.FirstName + " " + dto.LastName;
            user.IsActive = true;
            user.İsDeleted = false;
            user.SubscriptionType = SubscriptionType.Free;
            user.Id = user.SecurityStamp;
            user.EmailConfirmed = false;
            user.PhoneNumberConfirmed = false;
            user.AccessFailedCount = 0;
            user.TwoFactorEnabled = false;
            var userCreateResult = await _userService.CreateAsync(user);
            if (!userCreateResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.UserNotCreated);
                return response;
            }

            var applicationUserSecurityKey = new ApplicationUserSecurityKey()
            {
                Id = Guid.NewGuid(),
                UserId = userCreateResult.Data.Id,
                KeyValue = _securityHelper.CreateHash().HashedText,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };
            var accountSecurityCreatedResult = await _userSecurityKeyService.CreateAsync(applicationUserSecurityKey);
            if (!accountSecurityCreatedResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountSecurityNotCreated);
                return response;
            }

            user.PasswordHash = _securityHelper.CreateHash(dto.Password, accountSecurityCreatedResult.Data.KeyValue)
                .HashedText;

            user.UpdatedDate = DateTime.Now;
            var userUpdateResult = await _userService.UpdateAsync(user);
            if (!userUpdateResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountNotUpdated);
                return response;
            }

            if (!await _roleManager.RoleExistsAsync(dto.Role.GetDisplayName()))
                await _roleManager.CreateAsync(new IdentityRole(dto.Role.GetDisplayName()));
            if (await _roleManager.RoleExistsAsync(dto.Role.GetDisplayName()))
                await _userManager.AddToRoleAsync(user, dto.Role.GetDisplayName());
            
            var registerResult = _mapper.Map<AdminRegisterResultDto>(userCreateResult.Data);
            response.Success(registerResult);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<LoginResultDto>> Login(LoginDto dto)
    {
        var response = new ApiTransactionResult<LoginResultDto>();

        #region Validation
        var validator = new ValidationLoginDto();
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            response.Fail(ValidationHelper.ErrorValidation(validationResult));
            return response;
        }
        #endregion

        try
        {
            var user = await _userService.GetUserByUserName(_mapper.Map<GetUserByUserNameDto>(dto));
            if (!user.IsSuccess)
            {
                response.Fail(user.Messages);
                return response;
            }

            var checkPasswordDto = _mapper.Map<CheckPasswordDto>(user.Data);
            checkPasswordDto.PasswordHash = dto.Password;
            var checkPasswordResult = _userService.CheckPassword(checkPasswordDto).Result;
            if (!checkPasswordResult.IsSuccess)
            {
                response.Fail(checkPasswordResult.Messages);
                return response;
            }

            var userRoles = await _userService.GetUserRoles(user.Data.Id);
            if (!userRoles.IsSuccess)
            {
                response.Fail(userRoles.Messages);
                return response;
            }
        
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Data.UserName),
                new Claim(ClaimTypes.Sid, user.Data.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        
            foreach (var userRole in userRoles.Data)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole.Role));
            }

            var token = TokenHelper.CreateToken(authClaims);
            var refreshToken = TokenHelper.GenerateRefreshToken();
        
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.Data.RefreshToken = refreshToken;
            user.Data.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userService.UpdateAsync(user.Data);

            var responseData = new LoginResultDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
            
            response.Success(responseData);
            
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<RefreshTokenResultDto>> RefreshToken(RefreshTokenDto dto)
    {
        var response = new ApiTransactionResult<RefreshTokenResultDto>();
        try
        {
            var validator = new ValidationRefreshTokenDto();
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                response.Fail(ValidationHelper.ErrorValidation(validationResult));
                return response;
            }
            
            var accessToken = dto.AccessToken;
            var refreshToken = dto.RefreshToken;
            var principal = TokenHelper.GetPrincipalFromExpiredToken(accessToken);
            if (principal==null)
            {
                response.Fail(TransactionResultEnum.InvalidTokenOrRefreshToken);
                return response;
            }

            var user = _userService.GetUserByUserName(new GetUserByUserNameDto() { UserName = principal.Identity.Name })
                .Result;
            
            if (user == null || user.Data.RefreshToken != refreshToken || user.Data.RefreshTokenExpiryTime <= DateTime.Now)
            {
                response.Fail(TransactionResultEnum.InvalidTokenOrRefreshToken);
                return response;
            }
            
            var newAccessToken = TokenHelper.CreateToken(principal.Claims.ToList());
            var newRefreshToken = TokenHelper.GenerateRefreshToken();

            user.Data.RefreshToken = newRefreshToken;
            await _userService.UpdateAsync(user.Data);

            var responseData = new RefreshTokenResultDto()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }
}