namespace Mately.Core.Configs;

public class MongoConfig : IMongoConfig
{
    public string CategoryCollectionName { get; set; }
    public string ProductCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}