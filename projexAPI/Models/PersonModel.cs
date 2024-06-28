namespace projexAPI.Models
{
    public class PersonModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public PersonModel(int id, string name, string username, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}
