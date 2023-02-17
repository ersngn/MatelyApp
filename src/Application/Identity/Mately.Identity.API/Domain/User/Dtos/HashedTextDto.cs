using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.AccountSecurity.Dtos;

public class HashedTextDto : IDto
{
    public string HashedText { get; set; }
}