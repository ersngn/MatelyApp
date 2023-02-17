using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Identity.API.Domain.User.Model;

public class ApplicationUserSecurityKey : SqlEntityWithDate
{
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string KeyValue { get; set; }
}