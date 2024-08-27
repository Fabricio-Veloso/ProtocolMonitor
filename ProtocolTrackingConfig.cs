namespace MyBlazorPwa{
public class ProtocolTrackingConfig
  {
    /*responsable for configuring the protocol by user preferences*/
    
    //Expectativa de tempo para movimento padrão
    DateTime DefautMoveTimeExpectation {get ; set;}
    		 
  	//definir expectativa de tempo por setor.
    readonly List<string> sectors = new List<string>
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
  
    private class MTE_BySector
  	{
  	DateTime BySectorMoveExpectation {get; set;}
  	string? sector {get; set;}
  	}
  		 
  	//Definir a mudança de cor do protocol vizualizer de acordo com a distância de tempo em relação ás expectativas  de movimentação. 
    //"quero que o protocolo mude de verde para amarelo quando faltar 2 dias para o dia que escolhi como expectativa de movimentação do protocolo").
  }
}