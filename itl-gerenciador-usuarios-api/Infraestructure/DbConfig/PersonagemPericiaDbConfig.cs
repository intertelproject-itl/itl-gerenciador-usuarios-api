using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itl_gerenciador_usuarios_api.Infraestructure.DbConfig
{
    public class PersonagemPericiasDbConfig : IEntityTypeConfiguration<PersonagemPericiasModel>
    {
        public void Configure(EntityTypeBuilder<PersonagemPericiasModel> entity)
        {
            entity.ToTable("personagem_pericias");
            entity.HasKey(e => e.IdPericia);

            entity.HasIndex(e => e.IdPersonagem)
                  .IsUnique()
                  .HasDatabaseName("uq_personagem_pericias_id_personagem");

            entity.Property(e => e.IdPericia)
                  .HasColumnName("id_pericia");

            entity.Property(e => e.IdPersonagem)
                  .HasColumnName("id_personagem")
                  .IsRequired();

            // campos com default 0
            var propsWithDefault = new[]
            {
                "Atletismo","Briga","Concentracao","Conversa","Educacao","Evasao","Intimidacao",
                "Percepcao","Persuasao","Pilotagem","PrimeirosSocorros","Furtividade","Sobrevivencia",
                "Negociacao","Criminologia","Deducao","ResistirDrogasTortura","TecnologiaBasica",
                "SegurancaEletronica","Hackear","MecanicaTerrestre","Medicina","Ciencia",
                "ArmasDeFogo","ArmasPesadas","LutaCorpoACorpo"
            };

            // configure each property explicitly (keeps estilo do projeto)
            entity.Property(e => e.Atletismo).HasColumnName("atletismo").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Briga).HasColumnName("briga").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Concentracao).HasColumnName("concentracao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Conversa).HasColumnName("conversa").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Educacao).HasColumnName("educacao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Evasao).HasColumnName("evasao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Intimidacao).HasColumnName("intimidacao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Percepcao).HasColumnName("percepcao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Persuasao).HasColumnName("persuasao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Pilotagem).HasColumnName("pilotagem").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.PrimeirosSocorros).HasColumnName("primeiros_socorros").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Furtividade).HasColumnName("furtividade").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Sobrevivencia).HasColumnName("sobrevivencia").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Negociacao).HasColumnName("negociacao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Criminologia).HasColumnName("criminologia").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Deducao).HasColumnName("deducao").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.ResistirDrogasTortura).HasColumnName("resistir_drogas_tortura").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.TecnologiaBasica).HasColumnName("tecnologia_basica").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.SegurancaEletronica).HasColumnName("seguranca_eletronica").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Hackear).HasColumnName("hackear").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.MecanicaTerrestre).HasColumnName("mecanica_terrestre").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Medicina).HasColumnName("medicina").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.Ciencia).HasColumnName("ciencia").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.ArmasDeFogo).HasColumnName("armas_de_fogo").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.ArmasPesadas).HasColumnName("armas_pesadas").HasDefaultValue((short)0).IsRequired();
            entity.Property(e => e.LutaCorpoACorpo).HasColumnName("luta_corpo_a_corpo").HasDefaultValue((short)0).IsRequired();

            // Constraints 0..10
            entity.HasCheckConstraint("ck_per_atletismo", "atletismo BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_briga", "briga BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_concentracao", "concentracao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_conversa", "conversa BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_educacao", "educacao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_evasao", "evasao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_intimidacao", "intimidacao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_percepcao", "percepcao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_persuasao", "persuasao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_pilotagem", "pilotagem BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_primeiros_socorros", "primeiros_socorros BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_furtividade", "furtividade BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_sobrevivencia", "sobrevivencia BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_negociacao", "negociacao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_criminologia", "criminologia BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_deducao", "deducao BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_resistir_drogas_tortura", "resistir_drogas_tortura BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_tecnologia_basica", "tecnologia_basica BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_seguranca_eletronica", "seguranca_eletronica BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_hackear", "hackear BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_mecanica_terrestre", "mecanica_terrestre BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_medicina", "medicina BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_ciencia", "ciencia BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_armas_de_fogo", "armas_de_fogo BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_armas_pesadas", "armas_pesadas BETWEEN 0 AND 10");
            entity.HasCheckConstraint("ck_per_luta_corpo_a_corpo", "luta_corpo_a_corpo BETWEEN 0 AND 10");
        }
    }
}