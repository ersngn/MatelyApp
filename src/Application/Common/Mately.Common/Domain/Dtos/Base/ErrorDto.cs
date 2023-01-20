using Mately.Common.Enumeration;

namespace Mately.Common.Domain.Dtos.Base;

public class ErrorDto : IDto
{
    public Error Error { get; set; }
    public int ErrorCode { get; set; }
    public string Message { get; set; }
}