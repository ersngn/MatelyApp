using AutoMapper;
using Mately.Indentity.API.Repository.Device;

namespace Mately.Indentity.API.Services.Device;

public class DeviceService : IDeviceService
{
    private readonly IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;

    public DeviceService(IMapper mapper, IDeviceRepository deviceRepository)
    {
        _mapper = mapper;
        _deviceRepository = deviceRepository;
    }
}