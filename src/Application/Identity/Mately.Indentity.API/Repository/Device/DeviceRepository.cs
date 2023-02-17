using Mately.Indentity.API.Infrastructure;
using Mately.Indentity.API.Repository.Base;

namespace Mately.Indentity.API.Repository.Device;

public class DeviceRepository : EfCoreRepository<Domain.Device.Device>,IDeviceRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public DeviceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}