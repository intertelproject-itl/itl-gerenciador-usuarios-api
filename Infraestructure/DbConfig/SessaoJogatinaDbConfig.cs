using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itl_gerenciador_usuarios_api.Infraestructure.DbConfig
{
    public class SessaoJogatinaDbConfig : IEntityTypeConfiguration<SessaoJogatinaModel>
    {
        public void Configure(EntityTypeBuilder<SessaoJogatinaModel> entity)
        {
            entity.ToTable("sessao_jogatina");
            entity.HasKey(e => e.IdSessao);

            entity.Property(e => e.IdSessao)
                  .HasColumnName("id_sessao");
            entity.Property(e => e.Titulo)
                  .HasColumnName("titulo")
                  .HasMaxLength(100)
                  .IsRequired();
            entity.Property(e => e.Mestre)
                  .HasColumnName("mestre")
                  .HasMaxLength(100);
            entity.Property(e => e.LocalSessao)
                  .HasColumnName("local_sessao")
                  .HasMaxLength(100);
            entity.Property(e => e.Briefing)
                  .HasColumnName("briefing")
                  .HasMaxLength(2000);
            entity.Property(e => e.StatusSessao)
                  .HasColumnName("status_sessao")                                    
                  .IsRequired();
            entity.Property(e => e.Observacoes)
                  .HasColumnName("observacoes")
                  .HasMaxLength(1000);
            entity.Property(e => e.DataCriacao)
                  .HasColumnName("data_criacao")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .IsRequired();
            entity.Property(e => e.DataAtualizacao)
                  .HasColumnName("data_atualizacao")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                  .ValueGeneratedOnAddOrUpdate()
                  .IsRequired();
            entity.Property(e => e.Ativo)
                  .HasColumnName("ativo")
                  .IsRequired();
            entity.Property(e => e.Publica)
                  .HasColumnName("publica")
                  .IsRequired();
        }
    }
}