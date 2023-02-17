using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Indentity.API.Domain.AccountSecurity.Dtos;
using Mately.Indentity.API.Repository.AccountSecuriy;

namespace Mately.Indentity.API.Services.AccountSecurity;

public class AccountSecurityService : IAccountSecurityService
{
    private readonly IAccountSecurityRepository _accountSecurityRepository;
    private readonly IMapper _mapper;

    public AccountSecurityService(IAccountSecurityRepository accountSecurityRepository, IMapper mapper)
    {
        _accountSecurityRepository = accountSecurityRepository;
        _mapper = mapper;
    }

    public async Task<ApiTransactionResult<CreateAccountSecurityResultDto>> CreateAsync(Domain.Security.AccountSecurity accountSecurity)
    {
        var response = new ApiTransactionResult<CreateAccountSecurityResultDto>();

        try
        {
            var result = await _accountSecurityRepository.AddAsync(accountSecurity);
            var responseData = _mapper.Map<CreateAccountSecurityResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<GetAccountSecurityByAccountIdDto>> GetAccountSecurityByAccountId(Guid accountId)
    {
        var response = new ApiTransactionResult<GetAccountSecurityByAccountIdDto>();
        try
        {
            var accountSecurity = await _accountSecurityRepository.GetAsync(e => e.AccountId == accountId);
            if (accountSecurity == null)
            {
                response.Fail(TransactionResultEnum.AccountSecurityNotFound);
                return response;
            }

            var responseData = _mapper.Map<GetAccountSecurityByAccountIdDto>(accountSecurity);
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