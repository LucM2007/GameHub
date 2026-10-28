using GameHubApi.Enums;
using GameHubApi.Models;

namespace GameHubApi.DtoRequest
{
    public class RegisterRequestDto
    {
        public required string UserName { get; set; }
        public required string Email {  get; set;}
        public string? PhoneNumber { get; set;}
        public required string Password { get; set;}
        public bool IsPublisher { get; set;}
        public required string Location { get; set;}
        public bool Newsletter { get; set;}
    }
}
