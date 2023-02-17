using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Indentity.API.Domain.User.Dtos;
using Mately.Indentity.API.Repository.User;
using Microsoft.OpenApi.Extensions;

namespace Mately.Indentity.API.Services.User;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<ApiTransactionResult<CreateUserResultDto>> CreateAsync(Domain.User.User user)
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

    public async Task<ApiTransactionResult<CheckUserResultDto>> IsExist(string email, string phone, string username)
    {
        var response = new ApiTransactionResult<CheckUserResultDto>();
        try
        {
            var responseData = new CheckUserResultDto()
            {
                IsExist = true
            };

            var userByEmail = _userRepository.Get(e =>
                e.Email == email).ToList();
            
            if (userByEmail.Count>0)
            {
                response.Fail(TransactionResultEnum.EmailAlreadyExist,responseData);
                return response;
            }
            
            var userByPhone = _userRepository.Get(e =>
                e.PhoneNumber == phone).ToList();
            
            if (userByPhone.Count>0)
            {
                response.Fail(TransactionResultEnum.EmailAlreadyExist,responseData);
                return response;
            }
            
            var userByUserName = _userRepository.Get(e =>
                e.UserName == username).ToList();
            
            if (userByUserName.Count>0)
            {
                response.Fail(TransactionResultEnum.EmailAlreadyExist,responseData);
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
}