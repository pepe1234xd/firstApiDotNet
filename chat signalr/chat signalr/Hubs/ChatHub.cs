using chat_signalr.Mapping;
using Microsoft.AspNetCore.SignalR;

namespace chat_signalr.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IConnectionMapping<string> connectionMapping;

        public ChatHub(IConnectionMapping<string> connectionMapping)
        {
            this.connectionMapping = connectionMapping;
        }

        public record NewMessage(string UserName, string Message, string GroupName);

        public async Task JoinGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("NewUser", "Un usuario entró al canal");

        }

        public async Task LeaveGroup(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("LeftUser", "Un usuariosalió del canal");
        }

        public async Task SendMessage(NewMessage message)
        {
            await Clients.Group(message.GroupName).SendAsync("NewMessage", message);
        }

        public async Task SendAll(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            string name = Context.ConnectionId;
            connectionMapping.Add(name, Context.ConnectionId);
            await Clients.All.SendAsync("ReceiveMessage", "connected");
            await base.OnConnectedAsync();
      
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string name = Context.ConnectionId;
            connectionMapping.Removed(name, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
