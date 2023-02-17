using AutoMapper;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.Device.Dtos;
using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Repository.Device;
using Mately.Identity.API.Repository.User;

namespace Mately.Identity.API.Services.User;

public class UserDeviceService : IUserDeviceService
{
    private readonly IUserDeviceRepository _repository;
    private readonly IMapper _mapper;

    public UserDeviceService(IUserDeviceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<ApiTransactionResult<CreateDeviceResultDto>> CreateAsync(ApplicationUserDevice securityKey)
    {
        throw new NotImplementedException();
    }
}