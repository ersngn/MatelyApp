using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Security.Dtos;

public class ValidateHashDto : IDto
{
    public bool isValidated { get; set; }
}