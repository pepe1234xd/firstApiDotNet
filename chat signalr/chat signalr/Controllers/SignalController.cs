using BasicChat;
using chat_signalr.Hubs;
using chat_signalr.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace chat_signalr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalController : Controller
    {
        public static int contador = 0;
        private IHubContext<ChatHub> _chatHub;
        private readonly IConnectionMapping<string> _connectionMapping;

        public SignalController(IHubContext<ChatHub> chatHub, IConnectionMapping<string> connectionMapping)
        {
            this._chatHub = chatHub;
            this._connectionMapping = connectionMapping;
        }

        //using the function send
        [HttpPost]
        public async Task<IActionResult> SendAllAsync(string user, string message)
        {
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", user, message);
            
            return Ok(message );
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllUsers()
        {
           return Ok(_connectionMapping.getAll());
        }
    }
}