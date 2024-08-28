using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;


namespace MyBlazorPwa
{
    public class ProtocolData
    {
        public Header Header { get; set; } = new Header();
        public List<Moves> Moves { get; set; } = new List<Moves>();
        public ProtocolTrackingConfig TrackingConfig { get; set; } = new ProtocolTrackingConfig();

        // Construtor padrão
        public ProtocolData() { }

        // Método para preencher os dados a partir de uma string JSON
        public void LoadFromJson(string json)
        {
            DeserializeJson(json);
        }
        
        public void DeserializeJson(string json)
{
    var jsonObject = JsonDocument.Parse(json);
    
    // Carrega o Header
    var headerData = jsonObject.RootElement.GetProperty("Header");
    Header = new Header();

    foreach (var item in headerData.EnumerateArray())
    {
        var keyValue = item.GetString().Split(new[] { ":: ", ":" }, StringSplitOptions.None);
        
        // Verifica se keyValue possui exatamente 2 elementos
        if (keyValue.Length == 2)
        {
            switch (keyValue[0].Trim())
            {
                case "Solicitante":
                    Header.Solicitante = keyValue[1].Trim();
                    break;
                case "Numero/Ano":
                    var numeroAno = keyValue[1].Trim().Split('/');
                    Header.Numero = int.TryParse(numeroAno[0], out var numero) ? numero : (int?)null;
                    Header.Ano = int.TryParse(numeroAno[1], out var ano) ? ano : (int?)null;
                    break;
                case "Inspetoria":
                    Header.Inspetoria = keyValue[1].Trim();
                    break;
                case "Assunto":
                    Header.Assunto = keyValue[1].Trim();
                    break;
                case "Origem":
                    Header.Origem = keyValue[1].Trim();
                    break;
                case "Situação":
                    Header.Situacao = keyValue[1].Trim();
                    break;
                case "Destino":
                    Header.Destino = keyValue[1].Trim();
                    break;
                case "Sigiloso":
                    Header.Sigiloso = keyValue[1].Trim().Equals("Sim", StringComparison.OrdinalIgnoreCase);
                    break;
                case "Data de emissão":
                    Header.DataEmissao = DateTime.TryParse(keyValue[1].Trim(), out var data) ? data : (DateTime?)null;
                    break;
            }
        }
    }

    // Carrega as Moves
    var movesData = jsonObject.RootElement.GetProperty("Moves");
    Moves = new List<Moves>();

    foreach (var move in movesData.EnumerateArray())
    {
        var moveItem = new Moves
        {
            Passo = int.TryParse(move.GetProperty("Passo").GetString(), out var passo) ? passo : (int?)null,
            UsuarioOrigem = move.GetProperty("Usuário de Origem").GetString(),
            UsuarioDestino = move.GetProperty("Usuário de Destino").GetString(),
            SetorOrigem = move.GetProperty("Setor de Origem").GetString(),
            SetorDestino = move.GetProperty("Setor de Destino").GetString(),
            Descricao = move.GetProperty("Descrição").GetString(),
            Data = DateTime.TryParse(move.GetProperty("Data").GetString(), out var dataMov) ? dataMov : (DateTime?)null,
            Hora = TimeSpan.TryParse(move.GetProperty("Hora").GetString(), out var hora) ? hora : (TimeSpan?)null,
            Sigiloso = move.GetProperty("Sigiloso").GetString().Equals("Sim", StringComparison.OrdinalIgnoreCase)
        };

        Moves.Add(moveItem);
    }
}




    }

    public class Header
    {
        public string? Interessado { get; set; }
        public string? Solicitante { get; set; }
        public int? Numero { get; set; }
        public int? Ano { get; set; }
        public string? Inspetoria { get; set; }
        public string? Assunto { get; set; }
        public string? Origem { get; set; }
        public string? Situacao { get; set; }
        public string? Destino { get; set; }
        public bool? Sigiloso { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string? Descricao { get; set; }
    }

    public class Moves
    {
        public int? Passo { get; set; }
        public string? UsuarioOrigem { get; set; }
        public string? UsuarioDestino { get; set; }
        public string? SetorOrigem { get; set; }
        public string? SetorDestino { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? Hora { get; set; }
        public bool? Sigiloso { get; set; }
    }
}
