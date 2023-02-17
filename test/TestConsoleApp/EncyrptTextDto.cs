using Mately.Common.Domain.Dtos.Base;

namespace Mately.Indentity.API.Domain.Security.Dtos;

public class EncyrptTextDto : IDto
{
    public string? EncryptedText { get; set; }
}