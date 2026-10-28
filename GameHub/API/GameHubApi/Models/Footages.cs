using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Footages
    {
        [BsonId]
        public ObjectId FootageId = ObjectId.GenerateNewId();
        public bool Image;
        public string Name;
        public string Path;
    }
}
