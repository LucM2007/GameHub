using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Reviews
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ReviewsId = ObjectId.GenerateNewId();
        public bool Recommended;
        public string Text;
        public DateTime Created;
        public DateTime Updated;
    }
}
