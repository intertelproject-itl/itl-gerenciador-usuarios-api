using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasAtencaoModel : PericiasBaseModel
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

        [JsonProperty("concentracao_base")]
        public int ConcentracaoBase { get; set; }

        [JsonProperty("concentracao_nivel")]
        public int ConcentracaoNivel { get; set; }

        [JsonProperty("ocultar_revelar_objeto_base")]
        public int OcultarRevelarObjetoBase { get; set; }

        [JsonProperty("ocultar_revelar_objeto_nivel")]
        public int OcultarRevelarObjetoNivel { get; set; }

        [JsonProperty("leitura_labial_base")]
        public int LeituraLabialBase { get; set; }

        [JsonProperty("leitura_labial_nivel")]
        public int LeituraLabialNivel { get; set; }

        [JsonProperty("percepcao_base")]
        public int PercepcaoBase { get; set; }

        [JsonProperty("percepcao_nivel")]
        public int PercepcaoNivel { get; set; }

        [JsonProperty("rastrear_base")]
        public int RastrearBase { get; set; }

        [JsonProperty("rastrear_nivel")]
        public int RastrearNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
