using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itl_gerenciador_usuarios_api.Infraestructure.DbConfig
{
    public class PersonagemDbConfig : IEntityTypeConfiguration<PersonagemModel>
    {
        public void Configure(EntityTypeBuilder<PersonagemModel> entity)
        {
            entity.ToTable("personagens_base");
            entity.HasKey(e => e.IdPersonagem);

            entity.HasIndex(e => e.IdUsuario)
                  .HasDatabaseName("fk_personagens_usuario");

            entity.Property(e => e.IdPersonagem)
                  .HasColumnName("id_personagem");

            entity.Property(e => e.IdUsuario)
                  .HasColumnName("id_usuario")
                  .IsRequired();

            entity.Property(e => e.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.Conceito)
                  .HasColumnName("conceito")
                  .HasMaxLength(100);

            entity.Property(e => e.Papel)
                  .HasColumnName("papel")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.Idade)
                  .HasColumnName("idade");

            entity.Property(e => e.Genero)
                  .HasColumnName("genero")
                  .HasMaxLength(30);

            entity.Property(e => e.Origem)
                  .HasColumnName("origem")
                  .HasMaxLength(100);

            entity.Property(e => e.NivelReputacao)
                  .HasColumnName("nivel_reputacao")
                  .HasDefaultValue((short)0)
                  .IsRequired();

            entity.Property(e => e.HumanidadeAtual)
                  .HasColumnName("humanidade_atual");

            entity.Property(e => e.HumanidadeMax)
                  .HasColumnName("humanidade_max");

            entity.Property(e => e.Dinheiro)
                  .HasColumnName("dinheiro")
                  .HasColumnType("decimal(12,2)")
                  .HasDefaultValue(0m);

            entity.Property(e => e.Observacoes)
                  .HasColumnName("observacoes")
                  .HasMaxLength(1000);

            entity.Property(e => e.DataCriacao)
                  .HasColumnName("data_criacao")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Constraints do DDL
            entity.HasCheckConstraint("ck_personagens_dinheiro", "dinheiro >= 0");
            entity.HasCheckConstraint("ck_personagens_humanidade_atual", "(humanidade_atual IS NULL OR humanidade_atual >= 0)");
            entity.HasCheckConstraint("ck_personagens_humanidade_max", "(humanidade_max IS NULL OR humanidade_max >= 0)");
            entity.HasCheckConstraint("ck_personagens_idade", "(idade IS NULL OR idade >= 0)");
            entity.HasCheckConstraint("ck_personagens_reputacao", "nivel_reputacao >= 0");
        }
    }
}