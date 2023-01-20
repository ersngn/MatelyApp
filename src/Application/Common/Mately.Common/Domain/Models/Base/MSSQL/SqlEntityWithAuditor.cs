namespace Mately.Common.Domain.Models.Base.MSSQL;

public class SqlEntityWithAuditor : SqlEntityWithDate
{ 
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public Guid DeletedBy { get; set; }
}