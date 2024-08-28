using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MyBlazorPwa{
public class WebSocketService
{
    private readonly ClientWebSocket _webSocket = new ClientWebSocket();
    private readonly Uri _serverUri = new Uri("ws://localhost:5247");

    public async Task ConnectAsync()
    {
        await _webSocket.ConnectAsync(_serverUri, CancellationToken.None);
        Console.WriteLine("Conectado ao WebSocket.");
    }

    public async Task SendAsync(string message)
    {
        var bytes = Encoding.UTF8.GetBytes(message);
        await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
    }

    public async Task<string> ReceiveAsync()
{
    using var memoryStream = new MemoryStream();
    var buffer = new byte[1024];

    WebSocketReceiveResult result;

    do
    {
        result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        memoryStream.Write(buffer, 0, result.Count);
    } while (!result.EndOfMessage); // Continua recebendo até o final da mensagem

    return Encoding.UTF8.GetString(memoryStream.ToArray());
}

    public async Task CloseAsync()
    {
        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        _webSocket.Dispose();
    }
}

}