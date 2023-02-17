using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class DecryptTextDto : IDto
{
    public string? DecryptedText { get; set; }
}