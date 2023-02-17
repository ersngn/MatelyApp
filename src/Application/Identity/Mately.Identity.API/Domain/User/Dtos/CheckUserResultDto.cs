using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class CheckUserResultDto:IDto
{
    public bool IsExist { get; set; }
}