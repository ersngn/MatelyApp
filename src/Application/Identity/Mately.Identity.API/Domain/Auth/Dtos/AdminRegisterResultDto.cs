using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.Auth.Dtos;

public class AdminRegisterResultDto : IDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}