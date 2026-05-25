using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itl_gerenciador_usuarios_api.Infraestructure.DbConfig
{
    public class PersonagemAtributosDbConfig : IEntityTypeConfiguration<PersonagemAtributosModel>
    {
        public void Configure(EntityTypeBuilder<PersonagemAtributosModel> entity)
        {
            entity.ToTable("personagem_atributos");
            entity.HasKey(e => e.IdAtributo);

            entity.HasIndex(e => e.IdPersonagem)
                  .IsUnique()
                  .HasDatabaseName("uq_personagem_atributos_id_personagem");

            entity.Property(e => e.IdAtributo)
                  .HasColumnName("id_atributo");

            entity.Property(e => e.IdPersonagem)
                  .HasColumnName("id_personagem")
                  .IsRequired();

            entity.Property(e => e.Inteligencia)
                  .HasColumnName("inteligencia")
                  .IsRequired();

            entity.Property(e => e.Reflexos)
                  .HasColumnName("reflexos")
                  .IsRequired();

            entity.Property(e => e.Destreza)
                  .HasColumnName("destreza")
                  .IsRequired();

            entity.Property(e => e.Tecnica)
                  .HasColumnName("tecnica")
                  .IsRequired();

            entity.Property(e => e.Frieza)
                  .HasColumnName("frieza")
                  .IsRequired();

            entity.Property(e => e.Vontade)
                  .HasColumnName("vontade")
                  .IsRequired();

            entity.Property(e => e.Sorte)
                  .HasColumnName("sorte")
                  .IsRequired();

            entity.Property(e => e.Movimento)
                  .HasColumnName("movimento")
                  .IsRequired();

            entity.Property(e => e.Corpo)
                  .HasColumnName("corpo")
                  .IsRequired();

            entity.Property(e => e.Empatia)
                  .HasColumnName("empatia")
                  .IsRequired();


            // Constraints do DDL (1..10)
            entity.HasCheckConstraint("ck_attr_inteligencia", "inteligencia BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_reflexos", "reflexos BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_destreza", "destreza BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_tecnica", "tecnica BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_frieza", "frieza BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_vontade", "vontade BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_sorte", "sorte BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_movimento", "movimento BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_corpo", "corpo BETWEEN 1 AND 10");
            entity.HasCheckConstraint("ck_attr_empatia", "empatia BETWEEN 1 AND 10");
        }
    }
}