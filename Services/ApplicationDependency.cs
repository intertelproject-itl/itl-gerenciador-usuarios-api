using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Services.v1;

namespace itl_gerenciador_usuarios_api.Services
{
    public static class ApplicationDependency
    {
        public static void AddApplictionModule(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISessaoJogatinaService, SessaoJogatinaService>();
            services.AddScoped<IPersonagemService, PersonagemService>();
            services.AddScoped<IInventarioService, InventarioService>();
            services.AddScoped<IJogatinaService, JogatinaService>();
            services.AddScoped<ILojaNoturnaService, LojaNoturnaService>();
        }
    }
}
