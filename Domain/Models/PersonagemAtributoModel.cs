using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    [Table("personagem_atributos")]
    [Index(nameof(IdPersonagem), IsUnique = true)]
    public class PersonagemAtributosModel
    {
        [Key]
        [Column("id_atributo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdAtributo { get; set; }

        [Required]
        [Column("id_personagem")]
        public long IdPersonagem { get; set; }

        [Column("inteligencia")]
        [Range(1, 10)]
        public short Inteligencia { get; set; }

        [Column("reflexos")]
        [Range(1, 10)]
        public short Reflexos { get; set; }

        [Column("destreza")]
        [Range(1, 10)]
        public short Destreza { get; set; }

        [Column("tecnica")]
        [Range(1, 10)]
        public short Tecnica { get; set; }

        [Column("frieza")]
        [Range(1, 10)]
        public short Frieza { get; set; }

        [Column("vontade")]
        [Range(1, 10)]
        public short Vontade { get; set; }

        [Column("sorte")]
        [Range(1, 10)]
        public short Sorte { get; set; }

        [Column("movimento")]
        [Range(1, 10)]
        public short Movimento { get; set; }

        [Column("corpo")]
        [Range(1, 10)]
        public short Corpo { get; set; }

        [Column("empatia")]
        [Range(1, 10)]
        public short Empatia { get; set; }

        [Column("editavel")]
        [Range(0, 1)]
        public short Editavel { get; set; } = 1;
    }
}