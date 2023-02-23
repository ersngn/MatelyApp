using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Domain.Dtos.Pagination;

namespace Mately.Services.Match.Domain.Profile.Dtos;

public class GetProfileByDistanceDto : PaginationFilter,IDto
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public double Distance { get; set; }
    
}