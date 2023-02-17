using AutoMapper;
using FluentValidation;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;
using Mately.Indentity.API.Helpers.Security;
using Mately.Indentity.API.Helpers.Validation;
using Mately.Indentity.API.Services.Account;
using Mately.Indentity.API.Services.AccountSecurity;
using Mately.Indentity.API.Services.Auth.Validation;
using Mately.Indentity.API.Services.User;
using Microsoft.OpenApi.Extensions;

namespace Mately.Indentity.API.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IAccountService _accountService;
    private readonly IAccountSecurityService _accountSecurityService;
    private readonly ISecurityHelper _securityHelper;

    public AuthService(IMapper mapper, IUserService userService, IAccountService accountService,
        IAccountSecurityService accountSecurityService, ISecurityHelper securityHelper)
    {
        _mapper = mapper;
        _userService = userService;
        _accountService = accountService;
        _accountSecurityService = accountSecurityService;
        _securityHelper = securityHelper;
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

        var currentUser = _userService.IsExist(dto.Email, dto.PhoneNumber, dto.UserName).Result;
        if (!currentUser.IsSuccess)
        {
            response.Fail(currentUser.Messages);
            return response;
        }
        #endregion

        #region Operation
        try
        {
            #region User
            var user = _mapper.Map<Domain.User.User>(dto);
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            user.IsDeleted = false;
            var userCreateResult = await _userService.CreateAsync(user);
            if (!userCreateResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.UserNotCreated);
                return response;
            }
            #endregion

            #region Account
            var account = _mapper.Map<Domain.Account.Account>(userCreateResult.Data);
            account.Id = Guid.NewGuid();
            if (userCreateResult.Data != null) account.UserId = userCreateResult.Data.Id;
            account.SubscriptionType = SubscriptionType.Free;
            account.CreatedDate = DateTime.Now;
            account.IsActive = true;
            account.IsDeleted = false;
            account.Role = AccountRole.User;
            var accountCreatedResult = await _accountService.CreateAsync(account);
            if (!accountCreatedResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountNotCreated);
                return response;
            }
            #endregion

            #region AccounSecurity
            var accountSecurity = new Domain.Security.AccountSecurity()
            {
                Id = Guid.NewGuid(),
                AccountId = accountCreatedResult.Data.Id,
                AccountKey = _securityHelper.CreateHash().HashedText,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
            };
            var accountSecurityCreatedResult = await _accountSecurityService.CreateAsync(accountSecurity);
            if (!accountSecurityCreatedResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountSecurityNotCreated);
                return response;
            }
            #endregion

            #region Password
            account.Password = _securityHelper.CreateHash(dto.Password, accountSecurityCreatedResult.Data.AccountKey)
                .HashedText;
            account.UpdatedDate = DateTime.Now;
            var accountUpdatedResult = await _accountService.UpdateAsync(account);
            if (!accountUpdatedResult.IsSuccess)
            {
                response.Fail(TransactionResultEnum.AccountNotUpdated);
                return response;
            }
            #endregion

            var registerResult = _mapper.Map<RegisterResultDto>(userCreateResult.Data);
            response.Success(registerResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
        #endregion
    }

    public async Task<ApiTransactionResult<LoginResultDto>> Login(LoginDto dto)
    {
        var response = new ApiTransactionResult<LoginResultDto>();
        var validator = new ValidatorLoginDto();
        var validationResult = await validator.ValidateAsync(dto);
        
        if (!validationResult.IsValid)
        {
            response.Fail(ValidationHelper.ErrorValidation(validationResult));
            return response;
        }

        var account = await _accountService.GetByUserName(dto.UserName);
        if (!account.IsSuccess)
        {
            response.Fail(account.Messages);
            return response;
        }

        var accountSecurity = await _accountSecurityService.GetAccountSecurityByAccountId(account.Data.Id);
        if (!accountSecurity.IsSuccess)
        {
            response.Fail(accountSecurity.Messages);
            return response;
        }

        var isPasswordMatch =
            _securityHelper.ValidateHash(dto.Password, account.Data.Password, accountSecurity.Data.AccountKey);
        if (!isPasswordMatch.isValidated)
        {
            response.Fail(TransactionResultEnum.PasswordNotMatch);
            return response;
        }

        return response;
    }
}