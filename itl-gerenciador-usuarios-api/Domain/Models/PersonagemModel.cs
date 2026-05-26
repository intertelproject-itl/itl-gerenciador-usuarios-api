using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    [Table("personagens_base")]
    public class PersonagemModel
    {
        [Key]
        [Column("id_personagem")]
        public long IdPersonagem { get; set; }

        [Required]
        [Column("id_usuario")]
        public long IdUsuario { get; set; }

        [Required]
        [Column("id_sessao")]
        public long IdSessao { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("conceito")]
        public string? Conceito { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("papel")]
        public string? Papel { get; set; } = string.Empty;

        [Column("idade")]
        public int Idade { get; set; }

        [MaxLength(30)]
        [Column("genero")]
        public string? Genero { get; set; }

        [MaxLength(100)]
        [Column("origem")]
        public string? Origem { get; set; }

        [Column("nivel_reputacao")]
        public short? NivelReputacao { get; set; } = 0;

        [Column("humanidade_atual")]
        public short? HumanidadeAtual { get; set; }

        [Column("humanidade_max")]
        public short? HumanidadeMax { get; set; }

        [Column("dinheiro", TypeName = "decimal(12,2)")]
        public decimal? Dinheiro { get; set; } = 0m;

        [MaxLength(1000)]
        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Required]
        [Column("data_criacao")]
        public DateTime? DataCriacao { get; set; }

        [Required]
        [Column("hp_maximo")]
        public int HpMaximo { get; set; }

        [Required]
        [Column("hp_atual")]
        public int HpAtual { get; set; }

        [Required]
        [Column("protecao_armadura_maxima")]
        public int ProtecaoArmaduraMaxima { get; set; }

        [Required]
        [Column("protecao_armadura_atual")]
        public int ProtecaoArmaduraAtual { get; set; }

        [Required]
        [Column("sorte_maxima")]
        public int SorteMaxima { get; set; }

        [Required]
        [Column("sorte_atual")]
        public int SorteAtual { get; set; }

        [Required]
        [Column("ferimentos_criticos")]
        public string FerimentosCriticos { get; set; }


        [Column("portrait_base64")]
        public string PotraitBase64 { get; set; }
    }
}
