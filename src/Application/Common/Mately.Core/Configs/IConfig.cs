using System.Text.Json.Serialization;

namespace Mately.Core.Configs;

public interface IConfig
{
    [JsonIgnore]
    string Name => GetType().Name;
}