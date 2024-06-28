namespace projexAPI.Models
{
    public class LoginModel
    {
        public string emailUsername { get; set; }
        public string password { get; set; }

        public LoginModel(string emailUsername, string password)
        {
            this.emailUsername = emailUsername;
            this.password = password;
        }
    }
}
