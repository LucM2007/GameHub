using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class GameFootage
    {
        [Key]
        public ObjectId GameId;
        [Key]
        public ObjectId FootageId;
    }
}
