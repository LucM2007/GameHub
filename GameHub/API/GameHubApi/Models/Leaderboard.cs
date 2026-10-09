using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Leaderboard
    {
        public int GameId;
        public int Spot;
        public float Rating;
        public DateTime LastUpdated;
    }
}
