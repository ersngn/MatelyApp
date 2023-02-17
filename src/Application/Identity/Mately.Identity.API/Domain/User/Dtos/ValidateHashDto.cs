using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class ValidateHashDto : IDto
{
    public bool isValidated { get; set; }
}