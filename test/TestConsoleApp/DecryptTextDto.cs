using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Security.Dtos;

public class DecryptTextDto : IDto
{
    public string? DecryptedText { get; set; }
}