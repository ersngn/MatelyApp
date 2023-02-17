using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.Device.Dtos;
using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Repository.Device;

namespace Mately.Identity.API.Services.Device;

public class UserDeviceService : IUserDeviceService
{
    private readonly IUserDeviceRepository _repository;
    private readonly IMapper _mapper;

    public UserDeviceService(IUserDeviceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiTransactionResult<CreateDeviceResultDto>> CreateAsync(ApplicationUserDevice device)
    {
        var response = new ApiTransactionResult<CreateDeviceResultDto>();

        try
        {
            var result = await _repository.AddAsync(device);
            var responseData = _mapper.Map<CreateDeviceResultDto>(result);
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