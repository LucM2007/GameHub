using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class RefreshToken
    {
        [Key]
        public ObjectId RefreshTokenId;
        public ObjectId AccountId;
        public string TokenHash;
        public DateTime Created;
        public DateTime Expires;
        public DateTime Revoked;
        public string ReplacedByTokenId;
    }
}
