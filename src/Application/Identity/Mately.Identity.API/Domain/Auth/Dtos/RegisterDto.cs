using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Identity.API.Domain.Auth.Dtos;

public class RegisterDto : IDto
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}