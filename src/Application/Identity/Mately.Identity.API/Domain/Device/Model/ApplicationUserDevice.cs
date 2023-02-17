using Mately.Common.Domain.Models.Base.MSSQL;
using Mately.Identity.API.Domain.User.Model;

namespace Mately.Identity.API.Domain.Device.Model;

public class ApplicationUserDevice : SqlEntityWithDate
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string Value { get; set; }
    public  DateTime LastLoginDate { get; set; }
}