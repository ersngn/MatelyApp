using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.User.Dtos;

public class CreateUserResultDto:IDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}