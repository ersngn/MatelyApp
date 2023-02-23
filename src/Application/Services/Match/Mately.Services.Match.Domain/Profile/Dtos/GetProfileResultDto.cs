using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;
using Mately.Services.Match.Domain.Image.Model;

namespace Mately.Services.Match.Domain.Profile.Dtos;

public class GetProfileResultDto : IDto
{
    public string UserId { get; set; }
    public string FullName { get; set; }
    public int Distance { get; set; }
    public string? Summary { get; set; }
    public IList<Interest.Model.Interest>? Interests { get; set; }
    public Horoscope? Horoscope { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public string? BusinessTitle { get; set; }
    public string? School { get; set; }
    public string? City { get; set; }
    public IList<SexualOrientation>? SexualOrientations { get; set; }
    public IList<ProfileImage>? ProfileImages { get; set; }
}