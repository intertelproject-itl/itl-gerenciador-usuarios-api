using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasArmasModel : PericiasBaseModel
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

        [JsonProperty("arqueirismo_base")]
        public int ArqueirismoBase { get; set; }

        [JsonProperty("arqueirismo_nivel")]
        public int ArqueirismoNivel { get; set; }

        [JsonProperty("automatica_base")]
        public int AutomaticaBase { get; set; }

        [JsonProperty("automatica_nivel")]
        public int AutomaticaNivel { get; set; }

        [JsonProperty("armas_curtas_base")]
        public int ArmasCurtasBase { get; set; }

        [JsonProperty("armas_curtas_nivel")]
        public int ArmasCurtasNivel { get; set; }

        [JsonProperty("armas_pesadas_base")]
        public int ArmasPesadasBase { get; set; }

        [JsonProperty("armas_pesadas_nivel")]
        public int ArmasPesadasNivel { get; set; }

        [JsonProperty("fuzil_base")]
        public int FuzilBase { get; set; }

        [JsonProperty("fuzil_nivel")]
        public int FuzilNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
