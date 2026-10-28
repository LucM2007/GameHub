using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Commants
    {
        [BsonId]
        public ObjectId CommantsId = ObjectId.GenerateNewId();
        public ObjectId AccountId;
        public ObjectId ResponceId;
        public string text;
    }
}
