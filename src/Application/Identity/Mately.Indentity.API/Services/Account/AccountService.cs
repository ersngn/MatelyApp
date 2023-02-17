using System.Transactions;
using AutoMapper;
using FluentValidation;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Indentity.API.Domain.Account.Dtos;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;
using Mately.Indentity.API.Helpers.Security;
using Mately.Indentity.API.Helpers.Validation;
using Mately.Indentity.API.Repository.Account;
using Mately.Indentity.API.Services.AccountSecurity;
using Mately.Indentity.API.Services.User;
using Microsoft.OpenApi.Extensions;

namespace Mately.Indentity.API.Services.Account;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserService _userService;
    private readonly ISecurityHelper _securityHelper;
    private readonly IAccountSecurityService _accountSecurityService;

    public AccountService(IMapper mapper, IAccountRepository accountRepository, IUserService userService, ISecurityHelper securityHelper, IAccountSecurityService accountSecurityService)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
        _userService = userService;
        _securityHelper = securityHelper;
        _accountSecurityService = accountSecurityService;
    }

    /*
    public async Task<ApiTransactionResult<RegisterResultDto>> Register(RegisterDto dto)
    {
        var response = new ApiTransactionResult<RegisterResultDto>();
        var validator = new ValidatorRegisterDto();

        var validationResult = await validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorCode).ToList().Select(int.Parse)
                .Select(e => (TransactionResultEnum)e).ToList();
            var transactionMessages = new List<TransactionMessage>();
            foreach (var error in errors)
            {
                var transactionMessage = new TransactionMessage()
                {
                    Code = (int)error,
                    Description = error.GetDisplayName(),
                    Message = error
                };
                transactionMessages.Add(transactionMessage);
            }
            
            response.Fail(transactionMessages);
            return response;
        }

        var user = _mapper.Map<Domain.User.User>(dto);
        user.Id=Guid.NewGuid();
        user.CreatedDate=DateTime.Now;
        user.IsActive = true;
        user.IsDeleted = false;

        var userCreateResult = await _userService.CreateAsync(user);
        if (!userCreateResult.IsSuccess)
        {
            response.Fail(TransactionResultEnum.UserNotCreated);
            return response;
        }

        var account = _mapper.Map<Domain.Account.Account>(userCreateResult.Data);
        account.Id = Guid.NewGuid();
        if (userCreateResult.Data != null) account.UserId = userCreateResult.Data.Id;
        account.SubscriptionType = SubscriptionType.Free;
        account.CreatedDate=DateTime.Now;
        account.IsActive = true;
        account.IsDeleted = false;

        var accountCreatedResult = await CreateAsync(account);
        if (!accountCreatedResult.IsSuccess)
        {
            response.Fail(TransactionResultEnum.AccountNotCreated);
            return response;
        }

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

        account.Password = _securityHelper.CreateHash(dto.Password, accountSecurityCreatedResult.Data.AccountKey).HashedText;
        account.UpdatedDate=DateTime.Now;

        var accountUpdatedResult =  await UpdateAsync(account);
        if (!accountUpdatedResult.IsSuccess)
        {
            response.Fail(TransactionResultEnum.AccountNotUpdated);
            return response;
        }

        var registerResult = _mapper.Map<RegisterResultDto>(userCreateResult.Data);
        response.Success(registerResult);
        
        return response;
    }*/

    public async Task<ApiTransactionResult<CreateAccountResultDto>> CreateAsync(Domain.Account.Account account)
    {
        var response = new ApiTransactionResult<CreateAccountResultDto>();

        try
        {
            var result = await _accountRepository.AddAsync(account);
            var responseData = _mapper.Map<CreateAccountResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<UpdateAccountResultDto>> UpdateAsync(Domain.Account.Account account)
    {
        var response = new ApiTransactionResult<UpdateAccountResultDto>();

        try
        {
            var result = await _accountRepository.UpdateAsync(account);
            var responseData = _mapper.Map<UpdateAccountResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<GetAccountByFilterDto>> GetByUserName(string username)
    {
        var response = new ApiTransactionResult<GetAccountByFilterDto>();
        try
        {
            var result = await _accountRepository.GetByUserNameAsync(username);
            if (result==null)
            {
                response.Fail(TransactionResultEnum.UserNotFound);
                return response;
            }

            var responseData = _mapper.Map<GetAccountByFilterDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
        }

        return response;
    }
}