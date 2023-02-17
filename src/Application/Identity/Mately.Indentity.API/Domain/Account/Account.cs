using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Indentity.API.Domain.User.Models;

public class Account : SqlEntityWithDate
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Password { get; set; }
    public DateTime LastLoginDate { get; set; }
    
    public virtual ICollection<Device.Device> Devices { get; set; }
}