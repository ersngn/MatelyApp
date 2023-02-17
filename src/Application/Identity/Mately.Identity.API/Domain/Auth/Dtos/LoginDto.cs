using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Dtos;

public class LoginDto : IDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}