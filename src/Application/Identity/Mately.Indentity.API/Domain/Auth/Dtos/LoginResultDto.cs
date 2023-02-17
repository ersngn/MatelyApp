using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Auth.Dtos;

public class LoginResultDto : IDto
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string TokenType { get; } = "Bearer";
    public DateTime ExpireDateTime { get; set; }
}