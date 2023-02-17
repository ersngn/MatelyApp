using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Repository.SecurityKey;

namespace Mately.Identity.API.Services.SecurityKey;

public class UserSecurityKeyService : IUserSecurityKeyService
{
    private readonly IUserSecurityKeyRepository _repository;
    private readonly IMapper _mapper;

    public UserSecurityKeyService(IUserSecurityKeyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiTransactionResult<CreateSecurityKeyResultDto>> CreateAsync(ApplicationUserSecurityKey securityKey)
    {
        var response = new ApiTransactionResult<CreateSecurityKeyResultDto>();

        try
        {
            var result = await _repository.AddAsync(securityKey);
            var responseData = _mapper.Map<CreateSecurityKeyResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<GetSecurityKeyByUserIdResultDto>> GetUserSecurityKeyByUserId(string userId)
    {
        var response = new ApiTransactionResult<GetSecurityKeyByUserIdResultDto>();
        try
        {
            var accountSecurity = _repository.Get(e => e.UserId == userId).FirstOrDefault();
            if (accountSecurity == null)
            {
                response.Fail(TransactionResultEnum.AccountSecurityNotFound);
                return response;
            }

            var responseData = _mapper.Map<GetSecurityKeyByUserIdResultDto>(accountSecurity);
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