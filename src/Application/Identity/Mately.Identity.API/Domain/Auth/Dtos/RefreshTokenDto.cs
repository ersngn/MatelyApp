using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Dtos;

public class RefreshTokenDto : IDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}