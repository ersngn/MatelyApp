using Mately.Common.Domain.Dtos.Pagination;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Services.Match.Domain.Profile.Dtos;

namespace Mately.Services.Match.Business.Profile;

public interface IProfileService
{
    Task<ApiTransactionResult<CreateProfileResultDto>> Create(CreateProfileDto dto);
    Task<ApiTransactionResult<UpdateProfileResultDto>> Update(UpdateProfileDto dto);
    Task<ApiTransactionResult<GetProfileByIdResultDto>> GetById(string id);
    Task<ApiTransactionResult<DeleteProfileResultDto>> Delete(string id);
    Task<PaginationResponse<List<GetProfileResultDto>>> GetByDistance(string route, GetProfileByDistanceDto filter);
}