using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Game
    {
        [Key]
        private ObjectId GamesId;
        public int Category;
        public string Name;
        public string Description;
        public decimal Price;
        public DateTime Created;
        public DateTime Update;
    }
}
