using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class GameReviews
    {
        [BsonId]
        public ObjectId GameReviewId = ObjectId.GenerateNewId();
        public ObjectId GameId;
        public ObjectId FootageId;
    }
}
