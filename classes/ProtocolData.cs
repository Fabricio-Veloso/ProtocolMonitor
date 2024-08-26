
namespace PM.classes{
public class ProtocolData
{
  protected class Header
  {
      public string Interessado { get;  }
      public string Solicitante { get;  }
      public int Numero { get;  } 
      public int Ano { get;  }    
      public string Inspetoria { get; }
      public string Assunto { get; }
      public string Origem { get; }
      public string Situacao { get; }
      public string Destino { get; }
      public bool Sigiloso { get; }
      public DateTime? DataEmissao { get; }
      public string Descricao { get; }
  }
  protected class Moves
  {
      public int Passo { get;  }
      public string UsuarioOrigem { get;  }
      public string UsuarioDestino { get;  }
      public string SetorOrigem { get;  }
      public string SetorDestino { get;  }
      public string Descricao { get;  }
      public DateTime Data { get;  }
      public TimeSpan Hora { get;  }
      public bool Sigiloso { get;  }
  }
  public ProtocolData()
  {
    Header = new Header();
    Moves = new List<Moves>();
    trackingConfig = new TrackingConfig();
    
    
      
  }

}

}