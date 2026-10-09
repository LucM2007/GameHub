using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class NewsLetter
    {
        [Key]
        private ObjectId NewsLetterId;
        public string Content;
        public DateTime Send_At;
        public DateTime Updated_At;
        public DateTime Created_At;
    }
}
