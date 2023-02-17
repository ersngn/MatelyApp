using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class EncyrptTextDto : IDto
{
    public string? EncryptedText { get; set; }
}