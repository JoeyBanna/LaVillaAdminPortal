using Microsoft.AspNetCore.SignalR;

namespace BlazorApp.Hubs
{
    public class NotificationHub: Hub
    {
        public async Task SendMessage(string message, string sender, string receiver, string msgTitle)
        {
            await Clients.All.SendAsync("ReceiveMessage", sender, receiver, msgTitle, message);
        }
        public async Task ChatNotificationAsync(string message)
        {
            await Clients.All.SendAsync("ReceiveChatNotification", message);
        }
        public const string HubUrl = "/chat";

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
