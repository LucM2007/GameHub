using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameHubApi.Models;

public class Games
{
    [BsonId]
    public ObjectId GamesId { get; set; } = ObjectId.GenerateNewId();

    public int Category { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public DateTime Created { get; set; }

    public DateTime Update { get; set; }
}
