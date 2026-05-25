using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    public static class IntegrationDependency
    {
        public static void AddIntegrationModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Discord integration settings and http client
            services.Configure<DiscordSettings>(configuration.GetSection("Integrations:Discord"));
            services.AddHttpClient<DiscordIntegrationWrapper>();
        }
    }
}
