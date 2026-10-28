using GameHubApi.Data;
using GameHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace GameHubApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameHubDbContext _database;
        public GameController(GameHubDbContext database)
        {
            _database = database;
        }
        [HttpGet("Games")]
        public async Task<List<Games>> GetGames()
        {
            List<Games>? Games = await _database.Games.Find(_ => true).ToListAsync();
            return Games;
        }
        [HttpGet("Games/{id}")]
        public async Task<Games?> GetGameById(string id)
        {
            ObjectId GameId = ObjectId.Empty;
            if (!ObjectId.TryParse(id, out GameId))
                throw new InvalidCastException($"Invalid Game ID {id}");
            Games? game = await _database.Games.Find(g =>g.GamesId == GameId).SingleAsync();
            if (game == null)
            {
                throw new DataException("Game not found");
            }
            return game;
            }
        [HttpPost("Games")]
        public async Task<bool> CreateGame([FromBody] Games Game)
        {
            if (Game == null)
            {
                throw new ArgumentNullException(nameof(Game));
            }
            Game.GamesId = ObjectId.GenerateNewId();
            await _database.Games.InsertOneAsync(Game);
            if (Game.GamesId != ObjectId.Empty)
                return true;
            return false;

        }
    }
}
