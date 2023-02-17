using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Request;

public class LoginRequest : IRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}