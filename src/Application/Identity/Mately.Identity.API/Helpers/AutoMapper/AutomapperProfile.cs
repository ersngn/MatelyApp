using AutoMapper;
using Mately.Identity.API.Domain.Auth.Dtos;
using Mately.Identity.API.Domain.Auth.Request;
using Mately.Identity.API.Domain.Device.Dtos;
using Mately.Identity.API.Domain.Device.Model;
using Mately.Identity.API.Domain.User.Dtos;
using Mately.Identity.API.Domain.User.Model;

namespace Mately.Identity.API.Helpers.AutoMapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<RegisterRequest, RegisterDto>().ReverseMap();
        CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
        CreateMap<UpdateUserResultDto, RegisterResultDto>().ReverseMap();
        CreateMap<ApplicationUser, AdminRegisterDto>().ReverseMap();
        CreateMap<CreateUserResultDto, AdminRegisterResultDto>().ReverseMap();
        CreateMap<LoginDto, GetUserByUserNameDto>().ReverseMap();
        CreateMap<CheckPasswordDto, ApplicationUser>().ReverseMap();
        CreateMap<CreateDeviceResultDto, ApplicationUserDevice>().ReverseMap();
        CreateMap<CreateSecurityKeyResultDto, ApplicationUserSecurityKey>().ReverseMap();
        CreateMap<GetSecurityKeyByUserIdResultDto, ApplicationUserSecurityKey>().ReverseMap();
        CreateMap<CreateUserResultDto, ApplicationUser>().ReverseMap();
        CreateMap<UpdateUserResultDto, ApplicationUser>().ReverseMap();
        CreateMap<LoginRequest, LoginDto>().ReverseMap();
        CreateMap<RefreshTokenRequest, RefreshTokenDto>().ReverseMap();
    }
}