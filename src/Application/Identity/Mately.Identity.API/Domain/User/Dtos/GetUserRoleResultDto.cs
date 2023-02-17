using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class GetUserRoleResultDto : IDto
{
    public string Role { get; set; }
}