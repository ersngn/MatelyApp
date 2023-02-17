using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Device.Dtos;

public class CreateDeviceResultDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Value { get; set; }
}