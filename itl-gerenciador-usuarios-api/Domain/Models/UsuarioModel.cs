using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itl_gerenciador_usuarios_api.Domain.Models
{    
    [Table("usuarios")]
    public class UsuarioModel
    {
        [Key]
        [Column("id_usuario")]
        public long IdUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("senha_hash")]
        public string SenhaHash { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Column("ativo")]
        public byte Ativo { get; set; } = 1;

        [Required]
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }
    }
}