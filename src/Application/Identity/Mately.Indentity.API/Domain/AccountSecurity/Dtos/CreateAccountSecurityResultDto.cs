using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.AccountSecurity.Dtos;

public class CreateAccountSecurityResultDto : IDto
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string AccountKey { get; set; }
}