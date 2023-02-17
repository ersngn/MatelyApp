using Mately.Common.Domain.Dtos.Base;

namespace Mately.Identity.API.Domain.User.Dtos;

public class HashedTextDto : IDto
{
    public string HashedText { get; set; }
}