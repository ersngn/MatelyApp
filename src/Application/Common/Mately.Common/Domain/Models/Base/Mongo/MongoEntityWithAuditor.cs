using MongoDB.Bson.Serialization.Attributes;

namespace Mately.Common.Domain.Models.Base.Mongo;

public class MongoEntityWithAuditor : MongoEntityWithDate
{
    [BsonId] public string CreatedBy { get; set; }

    [BsonId] public string DeletedBy { get; set; }
}