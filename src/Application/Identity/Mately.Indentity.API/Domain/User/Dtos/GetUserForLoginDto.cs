using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.User.Dtos;

public class GetUserForLoginDto : IDto
{
    public Guid UserId { get; set; }
    public Guid AccountId { get; set; }
    public string AccountKey { get; set; }
    public string Password { get; set; }
}