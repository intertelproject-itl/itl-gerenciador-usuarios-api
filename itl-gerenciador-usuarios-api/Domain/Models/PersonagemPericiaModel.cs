using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
[Table("personagem_pericias")]
[Index(nameof(IdPersonagem), IsUnique = true)]
public class PersonagemPericiasModel
    {
        [Key]
        [Column("id_pericia")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPericia { get; set; }

        [Required]
        [Column("id_personagem")]
        public long IdPersonagem { get; set; }

        [Column("atletismo")]
        [Range(0, 10)]
        public short Atletismo { get; set; } = 0;

        [Column("briga")]
        [Range(0, 10)]
        public short Briga { get; set; } = 0;

        [Column("concentracao")]
        [Range(0, 10)]
        public short Concentracao { get; set; } = 0;

        [Column("conversa")]
        [Range(0, 10)]
        public short Conversa { get; set; } = 0;

        [Column("educacao")]
        [Range(0, 10)]
        public short Educacao { get; set; } = 0;

        [Column("evasao")]
        [Range(0, 10)]
        public short Evasao { get; set; } = 0;

        [Column("intimidacao")]
        [Range(0, 10)]
        public short Intimidacao { get; set; } = 0;

        [Column("percepcao")]
        [Range(0, 10)]
        public short Percepcao { get; set; } = 0;

        [Column("persuasao")]
        [Range(0, 10)]
        public short Persuasao { get; set; } = 0;

        [Column("pilotagem")]
        [Range(0, 10)]
        public short Pilotagem { get; set; } = 0;

        [Column("primeiros_socorros")]
        [Range(0, 10)]
        public short PrimeirosSocorros { get; set; } = 0;

        [Column("furtividade")]
        [Range(0, 10)]
        public short Furtividade { get; set; } = 0;

        [Column("sobrevivencia")]
        [Range(0, 10)]
        public short Sobrevivencia { get; set; } = 0;

        [Column("negociacao")]
        [Range(0, 10)]
        public short Negociacao { get; set; } = 0;

        [Column("criminologia")]
        [Range(0, 10)]
        public short Criminologia { get; set; } = 0;

        [Column("deducao")]
        [Range(0, 10)]
        public short Deducao { get; set; } = 0;

        [Column("resistir_drogas_tortura")]
        [Range(0, 10)]
        public short ResistirDrogasTortura { get; set; } = 0;

        [Column("tecnologia_basica")]
        [Range(0, 10)]
        public short TecnologiaBasica { get; set; } = 0;

        [Column("seguranca_eletronica")]
        [Range(0, 10)]
        public short SegurancaEletronica { get; set; } = 0;

        [Column("hackear")]
        [Range(0, 10)]
        public short Hackear { get; set; } = 0;

        [Column("mecanica_terrestre")]
        [Range(0, 10)]
        public short MecanicaTerrestre { get; set; } = 0;

        [Column("medicina")]
        [Range(0, 10)]
        public short Medicina { get; set; } = 0;

        [Column("ciencia")]
        [Range(0, 10)]
        public short Ciencia { get; set; } = 0;

        [Column("armas_de_fogo")]
        [Range(0, 10)]
        public short ArmasDeFogo { get; set; } = 0;

        [Column("armas_pesadas")]
        [Range(0, 10)]
        public short ArmasPesadas { get; set; } = 0;

        [Column("luta_corpo_a_corpo")]
        [Range(0, 10)]
        public short LutaCorpoACorpo { get; set; } = 0;

        [Column("editavel")]
        [Range(0, 1)]
        public short Editavel { get; set; } = 1;
    }
}