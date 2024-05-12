using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Szerver.Models;

namespace Szerver.WebSocket.Handlers
{
    public class MoodleHandler : WebSocketHandler
    {
        public MoodleHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task ReceiveAsync(System.Net.WebSockets.WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            await SendMessageToAllAsync(message);
        }

        public async Task NotifyEventAsync(Event @event)
        {
            var json = JsonSerializer.Serialize(@event);
            await SendMessageToAllAsync(json);
        }
    }
}
