using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class GetSecurityKeyByUserIdResultDto : IDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string KeyValue { get; set; }
}