using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasCorporaisModel : PericiasBaseModel
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

        [JsonProperty("atletismo_base")]
        public int AtletismoBase { get; set; }

        [JsonProperty("atletismo_nivel")]
        public int AtletismoNivel { get; set; }

        [JsonProperty("contorcionismo_base")]
        public int ContorcionismoBase { get; set; }

        [JsonProperty("contorcionismo_nivel")]
        public int ContorcionismoNivel { get; set; }

        [JsonProperty("dancar_base")]
        public int DancarBase { get; set; }

        [JsonProperty("dancar_nivel")]
        public int DancarNivel { get; set; }

        [JsonProperty("resistencia_base")]
        public int ResistenciaBase { get; set; }

        [JsonProperty("resistencia_nivel")]
        public int ResistenciaNivel { get; set; }

        [JsonProperty("resistencia_tortura_drogas_base")]
        public int ResistenciaTorturaDrogasBase { get; set; }

        [JsonProperty("resistencia_tortura_drogas_nivel")]
        public int ResistenciaTorturaDrogasNivel { get; set; }

        [JsonProperty("furtividade_base")]
        public int FurtividadeBase { get; set; }

        [JsonProperty("furtividade_nivel")]
        public int FurtividadeNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
