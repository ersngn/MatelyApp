using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.AccountSecurity.Dtos;

public class ValidateHashDto : IDto
{
    public bool isValidated { get; set; }
}