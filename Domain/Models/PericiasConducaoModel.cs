using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasConducaoModel : PericiasBaseModel
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

        [JsonProperty("dirigir_veiculo_terrestre_base")]
        public int DirigirVeiculoTerrestreBase { get; set; }

        [JsonProperty("dirigir_veiculo_terrestre_nivel")]
        public int DirigirVeiculoTerrestreNivel { get; set; }

        [JsonProperty("pilotar_veiculo_aereo_base")]
        public int PilotarVeiculoAereoBase { get; set; }

        [JsonProperty("pilotar_veiculo_aereo_nivel")]
        public int PilotarVeiculoAereoNivel { get; set; }

        [JsonProperty("pilotar_veiculo_maritimo_base")]
        public int PilotarVeiculoMaritimoBase { get; set; }

        [JsonProperty("pilotar_veiculo_maritimo_nivel")]
        public int PilotarVeiculoMaritimoNivel { get; set; }

        [JsonProperty("motocicleta_base")]
        public int MotocicletaBase { get; set; }

        [JsonProperty("motocicleta_nivel")]
        public int MotocicletaNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
