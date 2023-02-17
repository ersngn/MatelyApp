using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Indentity.API.Domain.Device;

public class Device : SqlEntityWithDate
{
    public Guid AccountId { get; set; }
    public Account.Account Account { get; set; }
    public string DeviceKey { get; set; }
    public DateTime LastLoginDate { get; set; }
}