using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Account.Dtos;

public class GetAccountFilter : IDto
{
    public TYPE Type { get; set; }
}