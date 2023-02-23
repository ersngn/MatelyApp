using Mately.Common.Domain.Models.Base.Mongo;

namespace Mately.Services.Match.Domain.Interest.Model;

public class Interest : MongoEntityWithAudit
{
    public string Name { get; set; }
}