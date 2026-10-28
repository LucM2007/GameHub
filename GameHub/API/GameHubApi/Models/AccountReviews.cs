using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class AccountReviews
    {
        [BsonId]
        public ObjectId AccountReviewId = ObjectId.GenerateNewId();
        public ObjectId AccountId;
        public ObjectId ReviewId;
    }
}
