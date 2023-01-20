using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mately.Common.Domain.Models.Base.Mongo;

public class MongoEntityWithDate : MongoEntityWithAudit
{
    [BsonElement]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime UpdatedDate { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime DeletedDate { get; set; }
}