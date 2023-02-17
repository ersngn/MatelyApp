using Mately.Common.Domain.Models.Base.MSSQL;

namespace Mately.Indentity.API.Domain.Security;

public class AccountSecurity : SqlEntityWithDate
{
    public Guid AccountId { get; set; }
    public Account.Account Account { get; set; }
    public string AccountKey { get; set; }
}