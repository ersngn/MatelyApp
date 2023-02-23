using Mately.Common.Domain.Dtos.Base;

namespace Mately.Services.Match.Domain.Profile.Request;

public class GetProfileByDistanceRequest : IRequest
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public double Distance { get; set; }
}