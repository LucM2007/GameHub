using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class AccountReview
    {

        [Key]
        public ObjectId AccountReviewId;
        public ObjectId AccountId;
        public ObjectId ReviewId;
    }
}
