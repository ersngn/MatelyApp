using AutoMapper;
using Mately.Indentity.API.Domain.Account;
using Mately.Indentity.API.Domain.Account.Dtos;
using Mately.Indentity.API.Domain.AccountSecurity.Dtos;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.Security;
using Mately.Indentity.API.Domain.User;
using Mately.Indentity.API.Domain.User.Dtos;

namespace Mately.Indentity.API.Helpers.AutoMapper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserResultDto, User>().ReverseMap();
        CreateMap<RegisterDto, User>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<UpdateAccountResultDto, Account>().ReverseMap();
        CreateMap<CreateAccountResultDto, Account>().ReverseMap();
        CreateMap<CreateUserResultDto, Account>().ReverseMap();
        CreateMap<CreateAccountSecurityResultDto, AccountSecurity>().ReverseMap();
        CreateMap<CreateUserResultDto, RegisterResultDto>().ReverseMap();
        
        
            


    }
}