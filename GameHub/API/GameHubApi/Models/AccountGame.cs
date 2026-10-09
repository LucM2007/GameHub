using MongoDB.Bson;

namespace GameHubApi.Models
{
    public class AccountGame
    {
        public ObjectId GameId;
        public ObjectId AccountId;
    }
}
