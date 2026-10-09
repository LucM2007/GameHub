using MongoDB.Bson;

namespace GameHubApi.Models
{
    public class AccountGame
    {
        [Key]
        public ObjectId GameId;

        [Key]
        public ObjectId AccountId;
    }
}
