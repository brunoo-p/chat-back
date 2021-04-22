using System.Threading.Tasks;
using Chat.Infrastructure.Entities;

namespace Chat.Infrastructure.Interface
{
    public interface IUser
    {
        User addUser(User user);
        User login(string nickname, string password);
        
    }
}