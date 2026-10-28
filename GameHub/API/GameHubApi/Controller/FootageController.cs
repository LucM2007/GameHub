using GameHubApi.Data;
using GameHubApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
namespace GameHubApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FootageController : ControllerBase
    {
        private readonly GameHubDbContext _database;
        public FootageController(GameHubDbContext database)
        {
            _database = database;
        }
        [HttpGet("Footage/{footageId}")]
        public async Task<ActionResult<Footages>> GetFootageAsync(string footageId)
        {
            if(!ObjectId.TryParse(footageId, out ObjectId footageObjectId))
                return BadRequest($"Invalid Footage ID: {footageId}");
            Footages? Footage = await _database.Footages.Find(f => f.FootageId == footageObjectId).SingleAsync();
            if(Footage == null)
                return BadRequest($"Footage with ID {footageId} not found.");
            return Footage;
        }
        [HttpGet("Footages/{gameId}")]
        public async Task<ActionResult<List<Footages>>> GetFootagesByGameIdAsync(string gameId)
        {
            if (!ObjectId.TryParse(gameId, out ObjectId gameObjectId))
                return BadRequest($"Invalid Game ID: {gameId}");

            List<GameFootages> gameFootages = await _database.GameFootages
                .Find(gf => gf.GameId == gameObjectId)
                .ToListAsync();

            List<ObjectId> footageIds = gameFootages
                .Select(gf => gf.FootageId)
                .ToList();

            if (footageIds.Count == 0)
                return Ok(new List<Footages>());

            List<Footages> footages = await _database.Footages
                .Find(Builders<Footages>.Filter.In(f => f.FootageId, footageIds))
                .ToListAsync();

            return Ok(footages);
        }

        [HttpPost("Footage")]
        public async Task<ActionResult<bool>> CreateFootage([FromBody] Footages footage)
        {

            if(footage == null)
            {
                return BadRequest("Footage cannot be null.");
            }
            footage.FootageId = ObjectId.GenerateNewId();
            await _database.Footages.InsertOneAsync(footage);
            return Created("Footage/" + footage.FootageId, true);
        }
        [HttpPost("Footage/Update")]
        public async Task<ActionResult<bool>> UpdateFootage([FromBody] Footages footage)
        {
            if(footage == null || footage.FootageId == ObjectId.Empty)
            {
                return BadRequest("Invalid footage data.");
            }
            var updateResult = await _database.Footages.ReplaceOneAsync(f => f.FootageId == footage.FootageId, footage);
            if (!updateResult.IsAcknowledged)
            {
                return BadRequest("Failed to update footage.");
            }
            return Ok(true);
        }
        [HttpDelete("Footage")]
        public async Task<ActionResult<bool>> DeleteFootage([FromBody] string footageId)
        {
            if (!ObjectId.TryParse(footageId, out ObjectId footageObjectId))
                return BadRequest($"Invalid Footage ID: {footageId}");

            var deleteResult = await _database.Footages.DeleteOneAsync(f => f.FootageId == footageObjectId);
            if (!deleteResult.IsAcknowledged)
            {
                return BadRequest("Failed to delete footage.");
            }
            return Ok(true);
        }

    }
}
