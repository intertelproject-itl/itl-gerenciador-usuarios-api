using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace itl_gerenciador_usuarios_api.Infraestructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PersonagemModel> Personagens { get; set; }
        public DbSet<SessaoJogatinaModel> SessoesJogatina { get; set; }
        public DbSet<PersonagemAtributosModel> PersonagemAtributos { get; set; }
        public DbSet<PersonagemPericiasModel> PersonagemPericias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioDbConfig());
            modelBuilder.ApplyConfiguration(new PersonagemDbConfig());
            modelBuilder.ApplyConfiguration(new SessaoJogatinaDbConfig());
            modelBuilder.ApplyConfiguration(new PersonagemAtributosDbConfig());
            modelBuilder.ApplyConfiguration(new PersonagemPericiasDbConfig());
        }
    }
}