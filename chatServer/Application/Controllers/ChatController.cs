using System;
using System.Threading.Tasks;
using Chat.Infrastructure.Entities;
using ChatApp.Server.Domain;
using ChatApp.Server.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        
        [HttpPost("message")]
        public async Task Post(ChatMessage message)
        {
            /*
                Persistence
            */
            try{

                await _chatHub.Clients.All.ReceivePrivateMessage(message);
            
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}