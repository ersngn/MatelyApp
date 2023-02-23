using AutoMapper;
using Mately.Common.Domain.Dtos.Pagination;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Mately.Core.Extentions;
using Mately.Core.Services.Uri;
using Mately.Service.Match.Repository.Profile;
using Mately.Services.Match.Domain.Profile.Dtos;
using Mately.Services.Match.Domain.Profile.Model;
using MongoDB.Bson.Serialization.Conventions;
using Exception = System.Exception;

namespace Mately.Services.Match.Business.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;
    private readonly IUriService _uriService;


    public ProfileService(IProfileRepository profileRepository, IMapper mapper, IUriService uriService)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _uriService = uriService;
    }

    public async Task<ApiTransactionResult<CreateProfileResultDto>> Create(CreateProfileDto dto)
    {
        var response = new ApiTransactionResult<CreateProfileResultDto>();
        try
        {
            var profile = _mapper.Map<UserProfile>(dto);
            profile.isActive = true;
            profile.isDeleted = false;
            profile.CreatedDate=DateTime.Now;
            profile.Id = profile.UserId;
            var result = await _profileRepository.AddAsync(profile);
            var responseData = _mapper.Map<CreateProfileResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<UpdateProfileResultDto>> Update(UpdateProfileDto dto)
    {
        var response = new ApiTransactionResult<UpdateProfileResultDto>();
        try
        {
            var profile = _mapper.Map<UserProfile>(dto);
            profile.isActive = true;
            profile.isDeleted = false;
            profile.UpdatedDate= DateTime.Now;
            var result = await _profileRepository.UpdateAsync(profile.Id, profile);
            var responseData = _mapper.Map<UpdateProfileResultDto>(result);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<GetProfileByIdResultDto>> GetById(string id)
    {
        var response = new ApiTransactionResult<GetProfileByIdResultDto>();
        try
        {
            var profile = _profileRepository.Get(e => e.isActive == true && e.isDeleted == false && e.Id == id)
                .FirstOrDefault();
            if (profile==null)
            {
                response.Fail(TransactionResultEnum.ProfileNotFount);
                return response;
            }
            
            var responseData = _mapper.Map<GetProfileByIdResultDto>(profile);
            response.Success(responseData);
        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }

    public async Task<ApiTransactionResult<DeleteProfileResultDto>> Delete(string id)
    {
        var response = new ApiTransactionResult<DeleteProfileResultDto>();
        try
        {
            var profile = await _profileRepository.GetByIdAsync(id);
            profile.isActive = false;
            profile.isDeleted = true;
            profile.DeletedDate = DateTime.Now;
            var result = await _profileRepository.UpdateAsync(profile.Id, profile);
            var responseData = new DeleteProfileResultDto()
            {
                Id = result.Id
            };
            response.Success(responseData);
        }
        catch (Exception e)
        {            
            response.UnKnownError(e.Message);
            return response;
        }

        return response;

    }

    public async Task<PaginationResponse<List<GetProfileResultDto>>> GetByDistance(string route, GetProfileByDistanceDto filter)
    {
        var response = new PaginationResponse<List<GetProfileResultDto>>();
        var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
        try
        {
            var profiles = await _profileRepository.GetByDistanceAsync(filter);
            if (profiles.Count!>0)
            {
                response.Fail(TransactionResultEnum.ProfilesNotFoundByDistance);
                return response;
            }

            //var profileResult = _mapper.Map<List<GetProfileResultDto>>(profiles);
            var responseData = new List<GetProfileResultDto>();
            foreach (var item in profiles)
            {
                var profile = new GetProfileResultDto()
                {
                    Distance = (int)Math.Sqrt(Math.Abs((int)(item.Location.Lat - filter.Lat)) ^
                                              2 + (Math.Abs((int)(item.Location.Lon - filter.Lon)) ^ 2)),
                    BusinessTitle = item.BusinessTitle,
                    City = item.City,
                    EducationLevel = item.EducationLevel,
                    FullName = item.MiddleName == null
                        ? item.FirstName + " " + item.LastName
                        : item.FirstName + " " + item.MiddleName + " " + item.LastName,
                    Horoscope = item.Horoscope,
                    Interests = item.Interests,
                    ProfileImages = item.ProfileImages,
                    School = item.School,
                    SexualOrientations = item.SexualOrientations,
                    UserId = item.UserId,
                    Summary = item.Summary,
                };
                responseData.Add(profile);
            }

            var totalRecords =   _profileRepository.ProfileCountByDistanceAsync(filter).Result;
            //response = new PaginationResponse<List<GetProfileResultDto>>(responseData, filter.PageNumber, filter.PageSize);
            response = PaginationExtention.CreatePagedReponse<GetProfileResultDto>(responseData, validFilter,
                (int)totalRecords, _uriService, route);
            response.Success();

        }
        catch (Exception e)
        {
            response.UnKnownError(e.Message);
            return response;
        }

        return response;
    }
}