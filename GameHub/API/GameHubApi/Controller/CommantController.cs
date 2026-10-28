using GameHubApi.Data;
using GameHubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using MongoDB.Driver;
using Superpower.Parsers;
using System.Collections.Specialized;

namespace GameHubApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommantController : ControllerBase
    {
        private readonly GameHubDbContext _database;
        public CommantController(GameHubDbContext database)
        {
            _database = database;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateComment([FromBody] Commants comment)
        {
            if (comment == null) return BadRequest("data not found");
            comment.CommantsId = ObjectId.GenerateNewId();
            await _database.Comments.InsertOneAsync(comment);
            return Created("comment/" + comment.CommantsId, true);
        }
        [HttpGet("{commantId}")]
        public async Task<ActionResult<Commants>> GetComment([FromBody] string commantId)
        {
            if (!ObjectId.TryParse(commantId, out ObjectId CommantObjectId)) return BadRequest("invalid commantId");
            Commants? Comment = await _database.Comments.Find(C => C.CommantsId == CommantObjectId).SingleAsync();
            if (Comment == null) return BadRequest("Comment dasnt exist");
            return Ok(Comment);
        }
        [HttpGet("Comments")]
        public async Task<ActionResult<List<Commants>>> GetComments([FromBody] string commentId)
        {
            if (!ObjectId.TryParse(commentId, out ObjectId CommantObjectId)) return BadRequest($"invalid id {commentId}");
            List<Commants>? Comment = await _database.Comments.Find(c => c.AccountId == CommantObjectId).ToListAsync();
            if (Comment == null || Comment.Count == 0) return BadRequest("No comments on your profile");
            return Ok(Comment);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteComment([FromBody] string commentId)
        {
            if (!ObjectId.TryParse(commentId, out ObjectId CommantObjectId)) return BadRequest($"invalid id format{commentId}");
            await _database.Comments.DeleteOneAsync(c => c.CommantsId == CommantObjectId);
            return Ok(true);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateComment([FromBody] Commants comment)
        {
            if (comment == null) return BadRequest("No comment given");
            if (comment.CommantsId == ObjectId.Empty) return BadRequest("No Id given");
            var Updated = await _database.Comments.ReplaceOneAsync(c => c.CommantsId == comment.CommantsId && c.AccountId == comment.AccountId, comment);
            if (!Updated.IsAcknowledged) return BadRequest("Could not update");
            return Ok(true);
        }
    }
}
