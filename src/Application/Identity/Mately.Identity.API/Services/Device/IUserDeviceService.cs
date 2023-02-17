using Mately.Common.Domain.Dtos.Transaction;
using Mately.Identity.API.Domain.Device.Dtos;
using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;

namespace Mately.Identity.API.Services;

public interface IUserDeviceService
{
    Task<ApiTransactionResult<CreateDeviceResultDto>> CreateAsync(
        ApplicationUserDevice securityKey);
}