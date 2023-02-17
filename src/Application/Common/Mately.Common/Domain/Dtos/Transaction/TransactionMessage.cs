using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;

namespace Mately.Common.Domain.Dtos.Transaction;

public class TransactionMessage : IDto
{
    public TransactionResultEnum Message { get; set; }
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
}