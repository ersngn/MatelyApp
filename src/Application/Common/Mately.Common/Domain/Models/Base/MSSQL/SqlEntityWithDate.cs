namespace Mately.Common.Domain.Models.Base.MSSQL;

public class SqlEntityWithDate : SqlEntityWithAudit
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}