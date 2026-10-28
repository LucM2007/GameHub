using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameHubApi.Models
{
    public class AccountGames
    {
        [BsonId]
        public ObjectId AccountGameId = ObjectId.GenerateNewId();
        public ObjectId GameId;
        public ObjectId AccountId;
    }
}
