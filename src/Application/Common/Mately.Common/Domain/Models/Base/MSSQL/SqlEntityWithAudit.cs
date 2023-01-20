namespace Mately.Common.Domain.Models.Base.MSSQL;

public class SqlEntityWithAudit :SqlEntity
{
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}