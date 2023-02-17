using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Request;

public class RegisterRequest : IRequest
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}