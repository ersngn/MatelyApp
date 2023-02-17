using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Indentity.API.Domain.User.Models;

public class Device : SqlEntityWithDate
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public DateTime LastLoginDate { get; set; }
}