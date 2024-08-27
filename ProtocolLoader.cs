using System.Text.Json;
namespace MyBlazorPwa{
  public class ProtocolLoader{
    async Task ReceiveAndDeserializeProtocol()
    {
        // Recebe a mensagem
        string receivedMessage = await WebSocketService.ReceiveAsync();
    
        if (!string.IsNullOrEmpty(receivedMessage))
        {
            // Deserializa a mensagem recebida
            Recivedprotocol = JsonSerializer.Deserialize<ProtocolData>(receivedMessage);
            // Agora você pode usar Recived_protocol como necessário
            if (Recived_protocol != null)
            {
                // Exemplo de uso
                Console.WriteLine("Protocol Data Deserialized Successfully.");
                return RecivedProtocol;
            }
            else
            {
                Console.WriteLine("Deserialization failed.");
            }
        }
    }
  }
}