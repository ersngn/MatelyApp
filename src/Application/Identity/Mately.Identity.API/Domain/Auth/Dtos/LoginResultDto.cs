using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Dtos;

public class LoginResultDto : IDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}