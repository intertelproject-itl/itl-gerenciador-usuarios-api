using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasPerformanceModel : PericiasBaseModel
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

        [JsonProperty("atuacao_base")]
        public int AtuacaoBase { get; set; }

        [JsonProperty("atuacao_nivel")]
        public int AtuacaoNivel { get; set; }

        [JsonProperty("tocar_instrumento_base")]
        public int TocarInstrumentoBase { get; set; }

        [JsonProperty("tocar_instrumento_nivel")]
        public int TocarInstrumentoNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
