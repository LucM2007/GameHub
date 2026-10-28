namespace GameHubApi.DTO
{
    public class LoginRequestDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }

        public LoginRequestDto(string email, string phoneNumber, string password)
        {
            if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException("Either email or phone number must be provided.");
            }
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

    }
}
