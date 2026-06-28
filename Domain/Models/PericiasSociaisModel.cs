using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasSociaisModel
    {
        [JsonIgnore]
        [JsonProperty("id_pericia")]
        public long IdPericia { get; set; }
        
        [JsonIgnore]
        [JsonProperty("id_sessao")]
        public long IdSessao { get; set; }

        [JsonIgnore]
        [JsonProperty("id_personagem")]
        public long IdPersonagem { get; set; }

        [JsonProperty("suborno_base")]
        public int SubornoBase { get; set; }

        [JsonProperty("suborno_nivel")]
        public int SubornoNivel { get; set; }

        [JsonProperty("oratoria_base")]
        public int OratoriaBase { get; set; }

        [JsonProperty("oratoria_nivel")]
        public int OratoriaNivel { get; set; }

        [JsonProperty("percepcao_humana_base")]
        public int PercepcaoHumanaBase { get; set; }

        [JsonProperty("percepcao_humana_nivel")]
        public int PercepcaoHumanaNivel { get; set; }

        [JsonProperty("interrogatorio_base")]
        public int InterrogatorioBase { get; set; }

        [JsonProperty("interrogatorio_nivel")]
        public int InterrogatorioNivel { get; set; }

        [JsonProperty("persuasao_base")]
        public int PersuasaoBase { get; set; }

        [JsonProperty("persuasao_nivel")]
        public int PersuasaoNivel { get; set; }

        [JsonProperty("cuidados_pessoais_base")]
        public int CuidadosPessoaisBase { get; set; }

        [JsonProperty("cuidados_pessoais_nivel")]
        public int CuidadosPessoaisNivel { get; set; }

        [JsonProperty("malandragem_base")]
        public int MalandragemBase { get; set; }

        [JsonProperty("malandragem_nivel")]
        public int MalandragemNivel { get; set; }

        [JsonProperty("negociacao_base")]
        public int NegociacaoBase { get; set; }

        [JsonProperty("negociacao_nivel")]
        public int NegociacaoNivel { get; set; }

        [JsonProperty("roupa_estilo_base")]
        public int RoupaEstiloBase { get; set; }

        [JsonProperty("roupa_estilo_nivel")]
        public int RoupaEstiloNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
