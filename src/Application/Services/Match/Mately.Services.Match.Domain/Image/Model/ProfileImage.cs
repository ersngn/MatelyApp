using Mately.Common.Domain.Models.Base.Mongo;

namespace Mately.Services.Match.Domain.Image.Model;

public class ProfileImage : MongoEntityWithDate
{
    public string UserId { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
}