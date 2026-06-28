using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    [Table("sessao_jogatina")]
    public class SessaoJogatinaModel
    {
        [Key]
        [Column("id_sessao")]
        public long IdSessao { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("mestre")]
        public string? Mestre { get; set; }

        [MaxLength(100)]
        [Column("local_sessao")]
        public string? LocalSessao { get; set; }

        [MaxLength(2000)]
        [Column("briefing")]
        public string? Briefing { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("status_sessao")]
        public int StatusSessao { get; set; }

        [MaxLength(1000)]
        [Column("observacoes")]
        public string? Observacoes { get; set; }

        [Required]
        [Column("ativo")]
        public int Ativo { get; set; } 

        [Required]
        [Column("publica")]
        public int Publica { get; set; }

        [Required]
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Required]
        [Column("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}

