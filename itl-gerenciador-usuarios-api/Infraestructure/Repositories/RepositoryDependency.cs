using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1;

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories
{
    public static class RepositoryDependency
    {
        public static void AddRepositoriesModule(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPersonagemRepository, PersonagemRepository>();
            services.AddScoped<ISessaoJogatinaRepository, SessaoJogatinaRepository>();
            services.AddScoped<IPersonagemAtributoRepository, PersonagemAtributoRepository>();
            services.AddScoped<IPersonagemPericiaRepository, PersonagemPericiaRepository>();

            // (manter registros originais)
        }
    }
}
