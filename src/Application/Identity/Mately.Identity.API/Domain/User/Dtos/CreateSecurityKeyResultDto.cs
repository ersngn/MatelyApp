using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class CreateSecurityKeyResultDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string KeyValue { get; set; }
}