using System.Threading.Tasks;
using Chat.Infrastructure.Entities;

namespace ChatApp.Server.Infrastructure.Interface
{
    public interface IChatClient
    {
        Task ReceivePrivateMessage(ChatMessage message);
        Task AddToGroup(string msgAddToGroup);
    }
}