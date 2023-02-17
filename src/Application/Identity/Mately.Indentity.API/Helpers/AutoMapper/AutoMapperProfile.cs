using AutoMapper;
using Mately.Indentity.API.Domain.Account;
using Mately.Indentity.API.Domain.Account.Dtos;
using Mately.Indentity.API.Domain.User;
using Mately.Indentity.API.Domain.User.Dtos;

namespace Mately.Core.AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserResultDto, User>().ReverseMap();
        CreateMap<RegisterDto, User>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<UpdateAccountResultDto, Account>().ReverseMap();
        CreateMap<CreateAccountResultDto, Account>().ReverseMap();
        

    }
}