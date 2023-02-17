using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Indentity.API.Domain.Account.Dtos;

public class GetAccountByFilterDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User.User User { get; set; }
    public string? Password { get; set; }
    public DateTime LastLoginDate { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    
    public virtual ICollection<Device.Device> Devices { get; set; }
}