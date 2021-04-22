using System.Threading.Tasks;
using Chat.Infrastructure.Entities;
using ChatApp.Server.Infrastructure.Interface;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Domain
{
    public class ChatHub : Hub<IChatClient>
    { 
        public async Task SendPrivateMessage(ChatMessage message)
        {
            //await Clients.User().SendPrivateMessage(chatMessage);
            await Clients.All.ReceivePrivateMessage(message);
        }
        
        

        // public async Task AddToGroup(string groupName)
        // {
        //     await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //     await Clients.Group(groupName).AddToGroup($"{Context.ConnectionId} has left the group {groupName}");
        // }

    }
}