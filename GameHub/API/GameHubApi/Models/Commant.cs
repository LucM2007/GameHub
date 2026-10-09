using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Commant
    {
        [Key]
        private ObjectId CommantsId;
        public ObjectId AccountId;
        public ObjectId ResponceId;
        public string text;
    }
}
