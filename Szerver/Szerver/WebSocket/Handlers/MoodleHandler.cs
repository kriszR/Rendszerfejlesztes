using System.Net.WebSockets;
using System.Text;

namespace Szerver.WebSocket.Handlers
{
    public class MoodleHandler : WebSocketHandler
    {
        public MoodleHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task ReceiveAsync(System.Net.WebSockets.WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = $"Új adat lett rögzítve: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
        }
    }
}
