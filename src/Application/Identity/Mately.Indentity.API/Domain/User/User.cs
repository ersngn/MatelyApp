using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Indentity.API.Domain.User;

public class User : SqlEntityWithDate
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}