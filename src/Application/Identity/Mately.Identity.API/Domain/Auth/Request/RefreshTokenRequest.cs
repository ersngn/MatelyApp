namespace Mately.Identity.API.Domain.Auth.Request;

public class RefreshTokenRequest
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}