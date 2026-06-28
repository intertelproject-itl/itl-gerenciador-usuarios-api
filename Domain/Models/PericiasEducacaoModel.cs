using Newtonsoft.Json;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class PericiasEducacaoModel : PericiasBaseModel
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

        [JsonProperty("idioma_base")]
        public int IdiomaBase { get; set; }

        [JsonProperty("idioma_nivel")]
        public int IdiomaNivel { get; set; }

        [JsonProperty("especialista_local_base")]
        public int EspecialistaLocalBase { get; set; }

        [JsonProperty("especialista_local_nivel")]
        public int EspecialistaLocalNivel { get; set; }

        [JsonProperty("contabilidade_base")]
        public int ContabilidadeBase { get; set; }

        [JsonProperty("contabilidade_nivel")]
        public int ContabilidadeNivel { get; set; }

        [JsonProperty("lidar_com_animais_base")]
        public int LidarComAnimaisBase { get; set; }

        [JsonProperty("lidar_com_animais_nivel")]
        public int LidarComAnimaisNivel { get; set; }

        [JsonProperty("burocracia_base")]
        public int BurocraciaBase { get; set; }

        [JsonProperty("burocracia_nivel")]
        public int BurocraciaNivel { get; set; }

        [JsonProperty("negocios_base")]
        public int NegociosBase { get; set; }

        [JsonProperty("negocios_nivel")]
        public int NegociosNivel { get; set; }

        [JsonProperty("composicao_base")]
        public int ComposicaoBase { get; set; }

        [JsonProperty("composicao_nivel")]
        public int ComposicaoNivel { get; set; }

        [JsonProperty("criminologia_base")]
        public int CriminologiaBase { get; set; }

        [JsonProperty("criminologia_nivel")]
        public int CriminologiaNivel { get; set; }

        [JsonProperty("criptografia_base")]
        public int CriptografiaBase { get; set; }

        [JsonProperty("criptografia_nivel")]
        public int CriptografiaNivel { get; set; }

        [JsonProperty("deducao_base")]
        public int DeducaoBase { get; set; }

        [JsonProperty("deducao_nivel")]
        public int DeducaoNivel { get; set; }

        [JsonProperty("educacao_base")]
        public int EducacaoBase { get; set; }

        [JsonProperty("educacao_nivel")]
        public int EducacaoNivel { get; set; }

        [JsonProperty("apostar_base")]
        public int ApostarBase { get; set; }

        [JsonProperty("apostar_nivel")]
        public int ApostarNivel { get; set; }

        [JsonProperty("pesquisa_biblioteca_base")]
        public int PesquisaBibliotecaBase { get; set; }

        [JsonProperty("pesquisa_biblioteca_nivel")]
        public int PesquisaBibliotecaNivel { get; set; }

        [JsonProperty("estrategia_base")]
        public int EstrategiaBase { get; set; }

        [JsonProperty("estrategia_nivel")]
        public int EstrategiaNivel { get; set; }

        [JsonProperty("sobrevivencia_base")]
        public int SobrevivenciaBase { get; set; }

        [JsonProperty("sobrevivencia_nivel")]
        public int SobrevivenciaNivel { get; set; }

        [JsonProperty("ciencia_base")]
        public int CienciaBase { get; set; }

        [JsonProperty("ciencia_nivel")]
        public int CienciaNivel { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_mudanca")]
        public DateTime? DataMudanca { get; set; }

        [JsonProperty("editavel")]
        public bool Editavel { get; set; }
    }
}
