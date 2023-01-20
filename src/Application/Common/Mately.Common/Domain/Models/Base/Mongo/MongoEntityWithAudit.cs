using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mately.Common.Domain.Models.Base.Mongo;

public class MongoEntityWithAudit : MongoEntity
{
    [BsonElement]
    [BsonRepresentation(BsonType.Boolean)]
    public bool isActive { get; set; }

    [BsonElement]
    [BsonRepresentation(BsonType.Boolean)]
    public bool isDeleted { get; set; }
}