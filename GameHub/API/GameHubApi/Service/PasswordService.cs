using GameHubApi.Models;
using Microsoft.AspNetCore.Identity;

namespace GameHubApi.Service
{
    public class PasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(Accounts account, string password)
        {
            return _hasher.HashPassword(account, password);
        }
        public bool CheckPassword(Accounts account, string password)
        {
            var result = _hasher.VerifyHashedPassword(account, account.Password, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}
