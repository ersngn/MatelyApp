namespace Mately.Core.Configs;

public interface IMongoConfig : IConfig
{
    string CategoryCollectionName { get; set; }
    string ProductCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}