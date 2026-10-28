using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Leaderboards
    {
        public ObjectId Id = ObjectId.GenerateNewId();
        public Guid LeaderBoardId = Guid.NewGuid();
        public ObjectId GameId;
        public int Spot;
        public float Rating;
        public DateTime LastUpdated;
    }
}
