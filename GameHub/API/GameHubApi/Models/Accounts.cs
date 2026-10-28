using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using GameHubApi.Enums; 
namespace GameHubApi.Models
{
    public class Accounts
    {
        [BsonId]
        public ObjectId AccountId { get; init; } = ObjectId.GenerateNewId();
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid PublicId { get; init; } = Guid.NewGuid();

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool Newsletter { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Role Role { get; set; } = Role.User;

        public string Location { get; set; } = string.Empty;

        public decimal Balance { get; set; }
    }
}
