using GameHubApi.Data;
using GameHubApi.DTO;
using GameHubApi.DtoRequest;
using GameHubApi.Models;
using GameHubApi.Service;
using GameHubApi.Enums;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Superpower.Parsers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GameHubApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly GameHubDbContext _database;
        private readonly PasswordService _passwordService;
        private readonly JWTService _jWTService;
        public AccountController(GameHubDbContext database, PasswordService passwordService, JWTService jWTService  )
        {
            _database = database;
            _passwordService = passwordService;
            _jWTService = jWTService;
        }
        //Account Functions

        [HttpPost("Account/Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestDto loginRequest)
        {
            Accounts? Account;
            try
            {
                if (loginRequest.Email == null)
                    if (loginRequest.PhoneNumber == null) return Unauthorized("No email or phonenumber given");
                    else
                        Account = await _database.Accounts.Find(A => A.PhoneNumber == loginRequest.PhoneNumber).SingleOrDefaultAsync();
                else
                    Account = await _database.Accounts.Find(A => A.Email == loginRequest.Email).SingleOrDefaultAsync();
                if (Account == null) return Unauthorized("No account found for these credentials");
                if (!_passwordService.CheckPassword(Account, loginRequest.Password)) return Unauthorized("No account found for these credentials");
                string Token = _jWTService.GiveToken(Account);
                return Ok(Token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal server error");
            }
        }

        [HttpPost("Account/Register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterRequestDto account)
        {
            if (account == null)
                return BadRequest("no data");
            Accounts Account = new()
            {
                Email = account.Email,
                Location = account.Location,
                Newsletter = account.Newsletter,
                UserName = account.UserName,
                PublicId = Guid.NewGuid()
            };
            if (account.IsPublisher)
                Account.Role = Role.Publisher;
            Account.Password = _passwordService.HashPassword(Account, account.Password);
            if(account.PhoneNumber !=null)
                Account.PhoneNumber = account.PhoneNumber;
            await _database.Accounts.InsertOneAsync(Account);
            string Token =_jWTService.GiveToken(Account);
            return Ok(Token);
        }
        [Authorize]
        [HttpPost("Account/Logout")]
        public bool Logout()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(user);
            return true;
        }

        //[HttpPut("Account")]
        //public bool UpdateAccount([FromBody] Accounts account)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete("Account")]
        //public bool DeleteAccount()
        //{
        //    throw new NotImplementedException();
        //}

        ////Friend management
        //[HttpPost("Account/SendFriendRequest")]
        //public bool SendFriendRequest([FromBody] string friendId)
        //{
        //    if (!ObjectId.TryParse(friendId, out ObjectId FriendObjectId))
        //        throw new InvalidCastException($"Invalid Friend ID {friendId}");
        //    throw new NotImplementedException();

        //}
        //[HttpPost("Account/CancelFriendRequest")]
        //public bool CancelFriendRequest([FromBody] string friendId)
        //{
        //    if (!ObjectId.TryParse(friendId, out ObjectId FriendObjectId))
        //        throw new InvalidCastException($"Invalid Friend ID {friendId}");
        //    throw new NotImplementedException();

        //}
        //[HttpPost("Account/AcceptFriendRequest")]
        //public bool AcceptFriendRequest([FromBody] string friendId)
        //{
        //    if (!ObjectId.TryParse(friendId, out ObjectId FriendObjectId))
        //        throw new InvalidCastException($"Invalid Friend ID {friendId}");
        //    throw new NotImplementedException();
        //}
        //[HttpPost("Account/DeclineFriendRequest")]
        //public bool DeclineFriendRequest([FromBody] string friendId)
        //{
        //    if (!ObjectId.TryParse(friendId, out ObjectId FriendObjectId))
        //        throw new InvalidCastException($"Invalid Friend ID {friendId}");
        //    throw new NotImplementedException();
        //}
        //[HttpPost("Account/GetFriendById")]
        //public Accounts GetFriendById([FromBody] string friendId)
        //{
        //    if (!ObjectId.TryParse(friendId, out ObjectId FriendObjectId))
        //        throw new InvalidCastException($"Invalid Friend ID {friendId}");
        //    throw new NotImplementedException();
        //}
        //[HttpPost("Account/GetFriends")]
        //public List<Accounts> GetFriends()
        //{
        //    throw new NotImplementedException();
        //}
        //[HttpPost("Account/GetFriendRequests")]
        //public List<Accounts> GetFriendRequests()
        //{
        //    throw new NotImplementedException();
        //}

        ////All account management endpoints
        //[HttpGet("Account/Id/{id}")]
        //public async Task<Accounts> GetAccountById(string id)
        //{
        //    if(!Guid.TryParse(id, out Guid guidId))
        //        throw new InvalidCastException($"Invalid Account ID {id}");
        //    var Account = await _database.Accounts.FindAsync(a => a.PublicId == guidId);

        //    if(Account == null)
        //         throw new InvalidOperationException($"Account with ID {id} not found.");

        //    // Make a DTO or a view model to return only the necessary data, if needed.
        //    throw new NotImplementedException();
        //}

        [HttpGet("Account/Search/{searchTerm}")]
        public List<AccountDTOs> SearchAccounts(string searchTerm)
        {
            var Account = _database.Accounts.Find(a => a.UserName.Contains(searchTerm)).ToList();
            // Make a DTO or a view model to return only the necessary data, if needed.
            List<AccountDTOs> AccountDTO = new List<AccountDTOs>();
            foreach (var account in Account)
            {
                AccountDTO.Add(new AccountDTOs
                {
                    PublicId = account.PublicId,
                    UserName = account.UserName
                });
            }
            return AccountDTO;

        }
    }
}
