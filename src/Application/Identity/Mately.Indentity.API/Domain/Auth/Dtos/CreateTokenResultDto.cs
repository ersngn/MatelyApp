using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Auth.Dtos;

public class CreateTokenResultDto : IDto
{
    public string Token { get; set; }
}