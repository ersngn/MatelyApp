using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Indentity.API.Domain.Account.Dtos;

public class CreateAccountResultDto : IDto 
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
}