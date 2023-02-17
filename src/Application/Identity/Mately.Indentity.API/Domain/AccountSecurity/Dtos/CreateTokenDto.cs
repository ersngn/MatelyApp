using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Indentity.API.Domain.AccountSecurity.Dtos;

public class CreateTokenDto : IDto
{
    public Guid AccountId { get; set; }
    public Guid UserId { get; set; }
    public User.User User { get; set; }
    public DateTime LastLoginDate { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public AccountRole Role { get; set; }
    public virtual ICollection<Device.Device> Devices { get; set; }
}