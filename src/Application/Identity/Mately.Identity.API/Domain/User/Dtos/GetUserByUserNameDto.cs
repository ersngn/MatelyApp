using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class GetUserByUserNameDto : IDto
{
    public string UserName { get; set; }
}