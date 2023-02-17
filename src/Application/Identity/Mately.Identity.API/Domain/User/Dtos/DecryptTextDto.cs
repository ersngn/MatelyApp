using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.AccountSecurity.Dtos;

public class DecryptTextDto : IDto
{
    public string? DecryptedText { get; set; }
}