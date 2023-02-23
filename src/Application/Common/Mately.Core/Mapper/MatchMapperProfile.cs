using AutoMapper;
using Mately.Services.Match.Domain.Profile.Dtos;
using Mately.Services.Match.Domain.Profile.Model;
using Mately.Services.Match.Domain.Profile.Request;

namespace Mately.Core.Mapper;

public class MatchMapperProfile : Profile
{
    public MatchMapperProfile()
    {
        CreateMap<CreateProfileDto, UserProfile>().ReverseMap();
        CreateMap<CreateProfileResultDto, UserProfile>().ReverseMap();
        CreateMap<UpdateProfileDto, UserProfile>().ReverseMap();
        CreateMap<UpdateProfileResultDto, UserProfile>().ReverseMap();
        CreateMap<GetProfileByIdResultDto, UserProfile>().ReverseMap();
        CreateMap<CreateProfileRequest, CreateProfileDto>().ReverseMap();
        CreateMap<UpdateProfileRequest, UpdateProfileDto>().ReverseMap();
        CreateMap<GetProfileByDistanceRequest, GetProfileByDistanceDto>().ReverseMap();
    }
}