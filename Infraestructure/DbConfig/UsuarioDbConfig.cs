using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itl_gerenciador_usuarios_api.Infraestructure.DbConfig
{
    public class UsuarioDbConfig : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> entity)
        {
            entity.ToTable("usuarios");
            entity.HasKey(e => e.IdUsuario);
            entity.HasIndex(e => e.Nickname)
                  .IsUnique();
            entity.Property(e => e.IdUsuario)
                  .HasColumnName("id_usuario");
            entity.Property(e => e.Nickname)
                  .HasColumnName("nickname")
                  .HasMaxLength(50)
                  .IsRequired();
            entity.Property(e => e.SenhaHash)
                  .HasColumnName("senha_hash")
                  .HasMaxLength(255)
                  .IsRequired();
            entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .HasMaxLength(100);
            entity.Property(e => e.Ativo)
                  .HasColumnName("ativo")
                  .HasDefaultValue(true);
            entity.Property(e => e.DataCriacao)
                  .HasColumnName("data_criacao")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");            
        }
    }
}
