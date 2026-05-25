using itl_gerenciador_usuarios_api.Domain.Interface.Integrations;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    public static class IntegrationDependecy
    {
        public static void AddIntegrationModule(this IServiceCollection services)
        {
            services.AddScoped<IDiscordIntegration, DiscordIntegration>();
        }
    }
}