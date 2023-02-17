using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class CheckUserDto : IDto
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Phone { get; set; }
}