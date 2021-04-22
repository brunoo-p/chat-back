namespace Chat.Infrastructure.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public User(string name, string nickname, string password)
        {
            Name = name;
            Nickname = nickname;
            Password = password;
        }
        
    }
}