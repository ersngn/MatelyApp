using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.Device.Dtos;
using Mately.Identity.API.Domain.Device.Model;

namespace Mately.Identity.API.Services.Device;

public interface IUserDeviceService
{
    Task<ApiTransactionResult<CreateDeviceResultDto>> CreateAsync(
        ApplicationUserDevice device);
}