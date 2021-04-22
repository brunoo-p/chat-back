using System.Threading.Tasks;
using Chat.Infrastructure.Entities;
using Chat.Infrastructure.Interface;
using chatServer.Infrastructure.Database;
using MongoDB.Driver;

namespace Chat.Domain.Repositories
{
    public class UserRepository : IUser
    {
        DbConnection _mongoDB;
        IMongoCollection<User> _userConllection;
        public UserRepository(DbConnection connection)
        {
            _mongoDB = connection;
            _userConllection = _mongoDB.database.GetCollection<User>("User");
        }
        public User addUser(User user)
        {
            try{
                var newUser = new User(
                    user.Name,
                    user.Nickname,
                    user.Password
                );

                _userConllection.InsertOneAsync(newUser);

                newUser.Password = "*";
                return newUser;
            }catch
            {
                return null;
            }
        }

        public User login(string nickname, string password)
        {
            var user = _userConllection.Find(Builders<User>.Filter
            .Where(_ => _.Nickname == nickname && _.Password == password));

            if(user == null)
            {
                return null;
            }
            
            return (User)user;
        }
    }
}