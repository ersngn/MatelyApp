using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mately.Common.Domain.Models.Base.Mongo;

public class MongoEntity : IEntity<string>
{
    [BsonId]
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
}