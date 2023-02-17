using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.User.Dtos;

public class CheckUserResultDto:IDto
{
    public bool IsExist { get; set; }
}