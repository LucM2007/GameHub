using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class RefreshTokens
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId RefreshTokenId = ObjectId.GenerateNewId();
        public ObjectId AccountId;
        public string TokenHash;
        public DateTime Created;
        public DateTime Expires;
        public DateTime Revoked;
        public string ReplacedByTokenId;
    }
}
