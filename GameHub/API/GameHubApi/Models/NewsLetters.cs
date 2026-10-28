using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameHubApi.Models
{
    public class NewsLetters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId NewsLetterId = ObjectId.GenerateNewId();
        public string Content;
        public DateTime Send_At;
        public DateTime Updated_At;
        public DateTime Created_At;
    }
}
