
namespace MyBlazorPwa{
  public class ProtocolData
  {
    public class Header
    {
        public string? Interessado {get; set; }
        public string? Solicitante {get; set; }
        public int? Numero {get; set; } 
        public int? Ano {get; set; }    
        public string? Inspetoria {get; set; }
        public string? Assunto {get; set; }
        public string? Origem {get; set; }
        public string? Situacao {get; set; }
        public string? Destino {get; set; }
        public bool? Sigiloso {get; set; }
        public DateTime? DataEmissao {get; set; }
        public string? Descricao {get; set; }
    }
    public class Moves
    {
        public int? Passo {get; set; }
        public string? UsuarioOrigem {get; set; }
        public string? UsuarioDestino {get; set; }
        public string? SetorOrigem {get; set; }
        public string? SetorDestino {get; set; }
        public string? Descricao {get; set; }
        public DateTime? Data {get; set; }
        public TimeSpan? Hora {get; set; }
        public bool? Sigiloso {get; set; }
    }
    public ProtocolData()
    {
      Header header = new Header();
      List<Moves> moves = new List<Moves>();
      ProtocolTrackingConfig trackingConfig = new ProtocolTrackingConfig();
    }
  
  }
}