using Mately.Common.Domain.Models.Base;
using Mately.Common.Domain.Models.Base.Mongo;
using Mately.Common.Enumeration;
using Mately.Services.Match.Domain.Image.Model;

namespace Mately.Services.Match.Domain.Profile.Model;

public class UserProfile : MongoEntityWithDate
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string? Summary { get; set; }
    public IList<Interest.Model.Interest>? Interests { get; set; }
    public Horoscope? Horoscope { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public string? BusinessTitle { get; set; }
    public string? School { get; set; }
    public string? City { get; set; }
    public bool Gender { get; set; }
    public IList<SexualOrientation>? SexualOrientations { get; set; }
    public Location.Model.Location Location { get; set; }
    public IList<ProfileImage>? ProfileImages { get; set; }
    
    
    
    
    
    
    
}