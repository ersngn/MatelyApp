using Mately.Common.Domain.Models.Base.MSSQL;
using Mately.Common.Enumeration;

namespace Mately.Indentity.API.Domain.Account;

public class Account : SqlEntityWithDate
{
    public Guid UserId { get; set; }
    public User.User User { get; set; }
    public string? Password { get; set; }
    public DateTime LastLoginDate { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public AccountRole Role { get; set; }
    
    public virtual ICollection<Device.Device> Devices { get; set; }
}