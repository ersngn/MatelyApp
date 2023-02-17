using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class CheckPasswordDto : IDto
{
    public string Id { get; set; }
    public string PasswordHash { get; set; }
}