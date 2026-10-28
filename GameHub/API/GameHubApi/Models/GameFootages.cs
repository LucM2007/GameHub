using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class GameFootages
    {
        [BsonId]
        public ObjectId GameFootageId = ObjectId.GenerateNewId();
        public ObjectId GameId;
        public ObjectId FootageId;
    }
}
