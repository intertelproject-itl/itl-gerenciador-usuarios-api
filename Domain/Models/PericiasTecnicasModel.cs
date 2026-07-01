using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasTecnicasModel : PericiasBaseModel
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

        [JsonProperty("tecnologia_veiculos_aereos_base")]
        public int TecnologiaVeiculosAereosBase { get; set; }

        [JsonProperty("tecnologia_veiculos_aereos_nivel")]
        public int TecnologiaVeiculosAereosNivel { get; set; }

        [JsonProperty("tecnologia_basica_base")]
        public int TecnologiaBasicaBase { get; set; }

        [JsonProperty("tecnologia_basica_nivel")]
        public int TecnologiaBasicaNivel { get; set; }

        [JsonProperty("cibertecnologia_base")]
        public int CibertecnologiaBase { get; set; }

        [JsonProperty("cibertecnologia_nivel")]
        public int CibertecnologiaNivel { get; set; }

        [JsonProperty("demolicoes_base")]
        public int DemolicoesBase { get; set; }

        [JsonProperty("demolicoes_nivel")]
        public int DemolicoesNivel { get; set; }

        [JsonProperty("eletronica_tec_seguranca_base")]
        public int EletronicaTecSegurancaBase { get; set; }

        [JsonProperty("eletronica_tec_seguranca_nivel")]
        public int EletronicaTecSegurancaNivel { get; set; }

        [JsonProperty("primeiros_socorros_base")]
        public int PrimeirosSocorrosBase { get; set; }

        [JsonProperty("primeiros_socorros_nivel")]
        public int PrimeirosSocorrosNivel { get; set; }

        [JsonProperty("falsificacao_base")]
        public int FalsificacaoBase { get; set; }

        [JsonProperty("falsificacao_nivel")]
        public int FalsificacaoNivel { get; set; }

        [JsonProperty("medicamentos_base")]
        public int MedicamentosBase { get; set; }

        [JsonProperty("medicamentos_nivel")]
        public int MedicamentosNivel { get; set; }

        [JsonProperty("tecnologia_veiculo_terrestre_base")]
        public int TecnologiaVeiculoTerrestreBase { get; set; }

        [JsonProperty("tecnologia_veiculo_terrestre_nivel")]
        public int TecnologiaVeiculoTerrestreNivel { get; set; }

        [JsonProperty("pintar_desenhar_esculpir_base")]
        public int PintarDesenharEsculpirBase { get; set; }

        [JsonProperty("pintar_desenhar_esculpir_nivel")]
        public int PintarDesenharEsculpirNivel { get; set; }

        [JsonProperty("fotografia_filmagem_base")]
        public int FotografiaFilmagemBase { get; set; }

        [JsonProperty("fotografia_filmagem_nivel")]
        public int FotografiaFilmagemNivel { get; set; }

        [JsonProperty("arrombamento_base")]
        public int ArrombamentoBase { get; set; }

        [JsonProperty("arrombamento_nivel")]
        public int ArrombamentoNivel { get; set; }

        [JsonProperty("furto_base")]
        public int FurtoBase { get; set; }

        [JsonProperty("furto_nivel")]
        public int FurtoNivel { get; set; }

        [JsonProperty("tecnologia_veiculo_maritimo_base")]
        public int TecnologiaVeiculoMaritimoBase { get; set; }

        [JsonProperty("tecnologia_veiculo_maritimo_nivel")]
        public int TecnologiaVeiculoMaritimoNivel { get; set; }

        [JsonProperty("tecnologia_armas_armeiro_base")]
        public int TecnologiaArmasArmeiroBase { get; set; }

        [JsonProperty("tecnologia_armas_armeiro_nivel")]
        public int TecnologiaArmasArmeiroNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
