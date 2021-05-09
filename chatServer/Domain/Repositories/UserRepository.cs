using System.Collections.Generic;
using Chat.Infrastructure.Entities;
using Chat.Infrastructure.Interface;


namespace Chat.Domain.Repositories
{
    public class UserRepository : IUser
    {
        List<User> list = new List<User>(); 
        public User addUser(User user)
        {
            var isExist = login(user.Nickname, user.Password);

            if(isExist != null){
                return null;
            }
    
            list.Add(user);
            return user;
        }

        public User login(string nickname, string password)
        {
            User finded = null;
            foreach (var user in list)
            {
                if(user.Nickname == nickname && user.Password == password){
                    finded = user;
                }
            }

            return finded;
        }
    }
}