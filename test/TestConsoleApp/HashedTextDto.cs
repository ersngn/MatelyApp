using Mately.Common.Domain.Dtos.Base;

namespace OneToOne.Domain.Dtos.Security;

public class HashedTextDto : IDto
{
    public string HashedText { get; set; }
}