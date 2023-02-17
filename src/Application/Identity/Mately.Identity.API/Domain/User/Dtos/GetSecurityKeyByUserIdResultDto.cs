using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class GetSecurityKeyByUserId : IDto
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string AccountKey { get; set; }
}