using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Account.Dtos;

public class GetAccountByUserNameDto : IDto
{
    public string UserName { get; set; }
}