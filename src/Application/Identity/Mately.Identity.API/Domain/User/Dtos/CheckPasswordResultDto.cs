using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class CheckPasswordResultDto:IDto
{
    public bool IsMatch { get; set; }
}