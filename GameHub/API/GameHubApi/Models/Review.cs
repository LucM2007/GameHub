using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Review
    {

        [Key]
        public ObjectId ReviewsId;
        public bool Recommended;
        public string Text;
        public DateTime Created;
        public DateTime Updated;
    }
}
