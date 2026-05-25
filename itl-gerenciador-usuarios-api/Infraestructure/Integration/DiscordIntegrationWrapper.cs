using itl_gerenciador_usuarios_api.Domain.Dto;
using Microsoft.Extensions.Options;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    // Thin wrapper that can be replaced or extended separately from the core integration
    public class DiscordIntegrationWrapper : DiscordIntegration
    {
        public DiscordIntegrationWrapper(IOptions<DiscordSettings> options, HttpClient http)
            : base(options, http)
        {
        }

        public override Task SendMessageAsync(DiscordMessageDTO message, CancellationToken ct)
        {
            // Could add additional logging or transformations here
            return base.SendMessageAsync(message, ct);
        }
    }
}
