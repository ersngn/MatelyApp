using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Services.Match.Domain.Profile.Dtos;

public class UpdateProfileDto : IDto
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
}