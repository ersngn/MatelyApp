using Mately.Common.Domain.Models.Base;
using Mately.Common.Enumeration;
using Microsoft.AspNetCore.Identity;

namespace Mately.Identity.API.Domain.User.Model;

public class ApplicationUser : IdentityUser, IEntity
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsActive { get; set; }
    public bool İsDeleted { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }


}