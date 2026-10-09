using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GameHubApi.Models
{
    public class Account
    {
        [Key]
        public ObjectId AccountId;
        public string UserName;
        public string Email;
        public string PhoneNumber;
        public string Password;
        public bool Newsletter;
        public enum Role;
        public string Location;
        public decimal Balance;
    }
}
