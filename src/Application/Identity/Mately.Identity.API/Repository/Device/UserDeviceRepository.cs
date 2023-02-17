using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Infrastructure;
using Mately.Identity.API.Repository.Base;

namespace Mately.Identity.API.Repository.Device;

public class UserDeviceRepository : EfCoreRepository<ApplicationUserDevice>,IUserDeviceRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public UserDeviceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}