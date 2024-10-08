using System.Collections.Generic;
using System;
using System.Text.Json;



namespace MyBlazorPwa
{
  public class ProtocolTrackingConfig{
  /*responsable for configuring the protocol by user preferences*/
  
  //Expectativa de tempo para movimento padrão
  DateTime DefautMoveTimeExpectation {get ; set;}
        
  //definir expectativa de tempo por setor.
  readonly static List<string> sectors = new List<string>
  {
    "CSIBE - Comissão de Seleção Interna de Bolsas de Estudo",
    "PRE - Presidência",
    "CAP - Coordenação de Atendimento ao Público",
    "GCR - Gerência de Compliance, Gestão de Risco e Controle Interno",
    "CLI - Comissão de Licitação",
    "CCC - Coordenação de Contratos e Convênios",
    "GGP - Gerência de Gestão de Pessoas",
    "SEG - Secretaria Geral",
    "STE - Superintendência Técnica",
    "CAI - Coordenação de Apoio às Inspetorias",
    "SERVICOS - AMBIENTE PROFISSIONAL/EMPRESA",
    "SAC - Secretaria de Apoio aos Colegiados",
    "CFI - Coordenação Financeira",
    "ARQUIVO - Arquivo",
    "GAB - Gabinete",
    "AEX - Assessoria Executiva",
    "TCE-PE - Tribunal de Contas do Estado de PE",
    "CEEMMQ - Câmara Especializada de Engenharia Mecânica, Metalúrgica e Química",
    "CEEST - Câmara Especializada de Engenharia de Segurança do Trabalho",
    "CEEC - Câmara Especializada de Engenharia Civil",
    "CEAG - Câmara Especializada de Agronomia",
    "NAT - Núcleo de Analistas Técnicos",
    "CEEE - Câmara Especializada de Engenharia Elétrica",
    "MPU - MINISTÉRIO PÚBLICO DA UNIÃO",
    "EPC - Equipe de Planejamento e Contratações",
    "CECP - Comissão Especial de Chamamento Público",
    "OUV - Ouvidoria",
    "DIR - Diretoria",
    "GAD - Gerência Administrativa",
    "CMS - Coordenação de Manutenção e Serviços Gerais",
    "CMA - Comissão de Meio Ambiente",
    "CAT - Coordenação de Análise Técnica",
    "GJU - Gerência Jurídica",
    "GCI - Gerência de Comunicação e Imprensa",
    "GRI - Gerência de Relacionamento Institucional",
    "AST - Assessoria de Saúde e Segurança do Trabalho",
    "CAR - Coordenação de Arrecadação e Cobrança",
    "CTP - Comitê Tecnológico Permanente",
    "CCO - Coordenação de Contabilidade",
    "GTI - Gerência de Tecnologia da Informação",
    "EVENTOS - Eventos",
    "TCU - Tribunal de Contas da União",
    "GFC - Gerência Financeira e Contábil",
    "NPF - Núcleo de Processos de Fiscalização",
    "CAA - Comissão de Acessibilidade Ambiental",
    "CD - Comissão de Divulgação",
    "CEAP - Comissão de Ensino e Atribuição Profissional",
    "CEP - Comissão de Ética Profissional",
    "CER - Comissão Eleitoral Regional",
    "CG CREA Jr PE - Comissão Gestora do CREA Jr - PE",
    "CM - Comissão do Mérito",
    "CRT - Comissão de Renovação do Terço",
    "COR - Comissão Organizadora do Congresso",
    "FCC - Fórum dos Coordenadores de Câmaras",
    "COTC - Comissão de Orçamento e Tomada de Contas",
    "PLENARIO - Plenário",
    "CDER - Colégio de Entidades Regionais",
    "CMG - Comitê de Modernização da Gestão",
    "SGE - Superintendência de Gestão",
    "GT - Grupo de Trabalho",
    "ABNT - ABNT",
    "SG - Suporte Gerencial",
    "DPO/LGPD - Proteção de Dados Pessoais",
    "1_TESLA - Time para Estudo de Soluções Locais Avançadas",
    "AUD - Auditoria",
    "CCS - Coordenação de Compras e Serviços",
    "GIE - Gerência de Integração e Excelência",
    "GFI - Gerência de Fiscalização",
    "COF - Coordenação de Fiscalização",
    "GAR - Gerência de Atendimento, Registro e Acervo Técnico",
    "CRA - Coordenação de Registro e Acervo",
    "CEGEM - Câmara Especializada de Geologia e Engenharia de Minas",
    "CEEF - Câmara Especializada de Engenharia Florestal",
    "CEEMMQH - Câmara Especializada de Engenharia Mecânica, Metalúrgica e Química Homologação",
    "CEESTH - Câmara Especializada de Engenharia de Segurança do Trabalho Homologação",
    "SAC-Homologação - SAC-Homologação Multicâmaras",
    "CEAGH - Câmara Especializada de Agronomia Homologação",
    "CEECH - Câmara Especializada de Engenharia Civil Homologação",
    "CEEEH - Câmara Especializada de Engenharia Elétrica Homologação",
    "CEEFH - Câmara Especializada de Engenharia Florestal Homologação",
    "CEGEMH - Câmara Especializada de Geologia e Engenharia de Minas Homologação",
    "PLENARIOH - Plenário Homologação"
  };

  public class MTE_BySector //Move time expectation
  {
    public DateTime BySectorMoveExpectation {get; set;}
    public string? sector {get; set;}
  }
      
  //Definir a mudança de cor do protocol vizualizer de acordo com a distância de tempo em relação ás expectativas  de movimentação. 
  //"quero que o protocolo mude de verde para amarelo quando faltar 2 dias para o dia que escolhi como expectativa de movimentação do protocolo").  
  }

  public static class ProtocolLoader{
    public static void PD_FromJson(string json,ref ProtocolData protocolData){
      var jsonDoc = JsonDocument.Parse(json);
        var root = jsonDoc.RootElement;

       if (root.TryGetProperty("Header", out var headerArray))
        {
            foreach (var item in headerArray.EnumerateArray())
            {
                string headerEntry = item.GetString();
                
                // Escolhe o delimitador adequado, primeiro verifica "::", depois ":"
                string[] parts = headerEntry.Contains("::") 
                    ? headerEntry.Split(new[] { "::" }, StringSplitOptions.None)
                    : headerEntry.Split(new[] { ":" }, StringSplitOptions.None);

                string key = parts[0].Trim();
                string value = parts.Length > 1 ? parts[1].Trim() : "Vazio";

                switch (key)
                {
                    case "Solicitante":
                        protocolData.Header.Solicitante = value;
                        break;
                    case "Descrição":
                      // Remove ou substitui o texto "PROCESSO DE AQUISIÇÕES DE BENS E SERVIÇOS - PABS" conforme as condições
                      if (value == "PROCESSO DE AQUISIÇÕES DE BENS E SERVIÇOS - PABS")
                      {
                          // Substitui a descrição inteira por "Protocolo Sem descrição"
                          value = "Protocolo Sem descrição";
                      }
                      else if (value.Contains("PROCESSO DE AQUISIÇÕES DE BENS E SERVIÇOS - PABS"))
                      {
                          // Remove apenas "PROCESSO DE AQUISIÇÕES DE BENS E SERVIÇOS - PABS" e mantém o restante do texto
                          value = value.Replace("PROCESSO DE AQUISIÇÕES DE BENS E SERVIÇOS - PABS", "").Trim();
                      }
                      protocolData.Header.Descricao = value;
                      break;


                    case "Interessado(s)":
                        protocolData.Header.Interessado = value;
                        break;
                    case "Numero/Ano":
                        protocolData.Header.Numero = value;
                        break;
                    case "Inspetoria":
                        protocolData.Header.Inspetoria = value;
                        break;
                    case "Assunto":
                        protocolData.Header.Assunto = value;
                        break;
                    case "Origem":
                        protocolData.Header.Origem = value;
                        break;
                    case "Situação":
                        protocolData.Header.Situacao = value;
                        break;
                    case "Destino":
                        protocolData.Header.Destino = value;
                        break;
                    case "Sigiloso":
                        protocolData.Header.Sigiloso = value;
                        break;
                    case "Data de emissão":
                        protocolData.Header.DataEmissao = value;
                        break;
                }
            }
        }

        if (root.TryGetProperty("Moves", out var movesArray))
        {
            foreach (var move in movesArray.EnumerateArray())
            {
                var moveValues = move.EnumerateArray();
                var moves = new Moves
                {
                  Passo = moveValues.ElementAtOrDefault(0).GetString() ?? "Vazio",
                  UsuarioOrigem = moveValues.ElementAtOrDefault(1).GetString() ?? "Vazio",
                  UsuarioDestino = moveValues.ElementAtOrDefault(2).GetString() ?? "Vazio",
                  SetorOrigem = moveValues.ElementAtOrDefault(3).GetString() ?? "Vazio",
                  SetorDestino = moveValues.ElementAtOrDefault(4).GetString() ?? "Vazio",
                  Descricao = moveValues.ElementAtOrDefault(5).GetString() ?? "Vazio",
                  Data = moveValues.ElementAtOrDefault(6).GetString() ?? "Vazio",
                  Hora = moveValues.ElementAtOrDefault(7).GetString() ?? "Vazio",
                  Sigiloso = moveValues.ElementAtOrDefault(8).GetString() ?? "Vazio"
                };

                protocolData.Moves.Add(moves);
            }
        }
    }
    
    public static void MiniPD_FromJson(string json, ref List<MiniProtocolData> miniProtocolDataList)
{
    var jsonDoc = JsonDocument.Parse(json);
    var root = jsonDoc.RootElement;

    if (root.TryGetProperty("MiniProtocols", out var miniProtocolsArray))
    {
        foreach (var miniProtocol in miniProtocolsArray.EnumerateArray())
        {
            var miniProtocolv = new MiniProtocolData
            {
                Numero = miniProtocol[0].GetString() ?? "Vazio",
                DataCadastro = miniProtocol[1].GetString() ?? "Vazio",
                Assunto = miniProtocol[2].GetString() ?? "Vazio",
                Descricao = miniProtocol[3].GetString() ?? "Vazio",
                LocalizacaoAtual = miniProtocol[5].GetString() ?? "Vazio",
                DataUltimoMovimento = miniProtocol[10].GetString() ?? "Vazio",
                HoraUltimoMovimento = miniProtocol[11].GetString() ?? "Vazio",
            };

            miniProtocolDataList.Add(miniProtocolv);
        }
    }
}

    public static void IdentifySponsor(ref ProtocolData protocol)
    {
        // Lista de setores e seus agentes
        var setoresComAgentes = new Dictionary<string, List<string>>()
        {
            {
                "Recife/Sede - (CLI) Comissão de Licitação", 
                new List<string>
                {
                    "Diogo Bernardo da Silva",
                    "Hugo Vasconcelos Fernandes da Costa",
                    "João Cesar dos Santos",
                    "Marilia Rosa Silva de Oliveira",
                    "Rerivaldo de Amarantes",
                    "Sandro da Costa Figueiroa"
                }
            }
        };
    
        // Inicializa o responsável como "Sem responsavel"
        protocol.Responsavel = "Sem responsavel";
    
        // Percorre todas as movimentações do protocolo em ordem
        if (protocol.Moves != null && protocol.Moves.Count > 0)
        {
            foreach (var movimentacao in protocol.Moves)
            {
                // Verifica se a descrição não é "Passo Inicial." ou "Protocolo recebido para análise. Passo automático!"
                if (movimentacao.Descricao != "Passo Inicial." && movimentacao.Descricao != "Protocolo recebido para análise. Passo automático!")
                {
                    // Verifica se o setor de origem e destino não são nulos
                    if (!string.IsNullOrEmpty(movimentacao.SetorOrigem) && !string.IsNullOrEmpty(movimentacao.SetorDestino))
                    {
                        // Verifica se o setor de origem e destino estão no dicionário de setores com agentes
                        if (setoresComAgentes.ContainsKey(movimentacao.SetorOrigem) 
                            && setoresComAgentes.ContainsKey(movimentacao.SetorDestino))
                        {
                            // Verifica se o usuário de destino pertence à lista de agentes do setor
                            if (!string.IsNullOrEmpty(movimentacao.UsuarioDestino) 
                                && setoresComAgentes[movimentacao.SetorDestino].Contains(movimentacao.UsuarioDestino))
                            {
                                // Atualiza o responsável com o usuário de destino
                                protocol.Responsavel = movimentacao.UsuarioDestino;
                            }
                        }
                    }
                }
            }
        }
    }


  }
  
  public class MiniProtocolData
  {
    public string? DataUltimoMovimento { get; set; } = "Vazio";
    public string? HoraUltimoMovimento { get; set; } = "Vazio";
    public string? LocalizacaoAtual    { get; set; } = "Vazio";
    public string? Interessado         { get; set; } = "Vazio";
    public string? Numero              { get; set; } = "Vazio";
    public string? Assunto             { get; set; } = "Vazio";
    public string? Descricao           { get; set; } = "Vazio";
    public string? DataCadastro        { get; set; } = "Vazio";

    // Remova a propriedade recursiva ou modifique conforme necessário
    // public MiniProtocolData miniProtocolData { get; set; } = new MiniProtocolData();
  }

  public class ProtocolData
{
    public Header Header { get; set; } = new Header();
    public List<Moves> Moves { get; set; } = new List<Moves>();
    public ProtocolTrackingConfig trackingConfig { get; set; } = new ProtocolTrackingConfig();
    
    // Campo para armazenar o responsável
    public string? Responsavel { get; set; } = "Sem responsavel";

    // Construtor que chama a função de identificação do responsável
    public ProtocolData()
    {
      
    }

    // Função para retornar a data do último movimento
    public string GetDataUltimoMovimento()
    {
        if (Moves != null && Moves.Count > 0)
        {
            return Moves.Last().Data ?? "Sem data"; // Retorna uma string padrão se Data for nulo
        }
        return "Sem movimentos"; // Se não houver movimentos
    }

    // Função para retornar o setor do último movimento
    public string GetSetorUltimoMovimento()
    {
        if (Moves != null && Moves.Count > 0)
        {
            return Moves.Last().SetorDestino ?? "Sem setor"; // Retorna o setor do último movimento
        }
        return "Sem movimentações"; // Se não houver movimentos
    }

}

  public class Header{
    public string? Interessado         { get; set; } = "Vazio";
    public string? Solicitante         { get; set; } = "Vazio";
    public String? Numero              { get; set; } = "Vazio";
    public string? Inspetoria          { get; set; } = "Vazio";
    public string? Assunto             { get; set; } = "Vazio";
    public string? Origem              { get; set; } = "Vazio";
    public string? Situacao            { get; set; } = "Vazio";
    public string? Destino             { get; set; } = "Vazio";
    public String? Sigiloso            { get; set; } = "Vazio";
    public string? DataEmissao         { get; set; } = "Vazio";
    public string? Descricao           { get; set; } = "Vazio";

  }
  
  public class Moves{
    public string? Passo { get; set; } = "Vazio";
    public string? UsuarioOrigem { get; set; } = "Vazio";
    public string? UsuarioDestino { get; set; } = "Vazio";
    public string? SetorOrigem { get; set; } = "Vazio";
    public string? SetorDestino { get; set; } = "Vazio";
    public string? Descricao { get; set; } = "Vazio";
    public string? Data { get; set; } = "Vazio";
    public string? Hora { get; set; } = "Vazio";
    public string Sigiloso { get; set; } = "Vazio";
  }
  
  public class ByTimeColorConfig
    {
        /*TIME*/
        public int? ConfigExpectativaMovimentacao  { get; set; } = 0;
        public int? ConfigVerde  { get; set; } = 0;
        public int? ConfigAmarelo  { get; set; } = 0;
        public int? ConfigVermelho  { get; set; } = 0;

        /*COLORS*/
        public string ColorVerde { get; set; } = $"color:{MudBlazor.Colors.Green.Lighten2};";
        public string ColorAmarelo { get; set; } = $"color:{MudBlazor.Colors.Yellow.Lighten3};";
        public string ColorVermelho { get; set; } = $"color:{MudBlazor.Colors.Red.Lighten1};";
        public string ColorPreto { get; set; } = $"color:{MudBlazor.Colors.Shades.Black};";
    }
}


    

