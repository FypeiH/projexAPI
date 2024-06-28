namespace projexAPI.Models
{
    public class SignUpModel
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public SignUpModel(string name, string username, string email, string password)
        {
            this.name = name;
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
