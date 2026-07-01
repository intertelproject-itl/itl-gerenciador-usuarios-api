using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasLutaModel : PericiasBaseModel
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

        [JsonProperty("briga_base")]
        public int BrigaBase { get; set; }

        [JsonProperty("briga_nivel")]
        public int BrigaNivel { get; set; }

        [JsonProperty("evasao_base")]
        public int EvasaoBase { get; set; }

        [JsonProperty("evasao_nivel")]
        public int EvasaoNivel { get; set; }

        [JsonProperty("artes_marciais_base")]
        public int ArtesMarciaisBase { get; set; }

        [JsonProperty("artes_marciais_nivel")]
        public int ArtesMarciaisNivel { get; set; }

        [JsonProperty("armas_brancas_base")]
        public int ArmasBrancasBase { get; set; }

        [JsonProperty("armas_brancas_nivel")]
        public int ArmasBrancasNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}