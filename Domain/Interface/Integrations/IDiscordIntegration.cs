using itl_gerenciador_usuarios_api.Domain.Dto;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Integrations
{
    public interface IDiscordIntegration
    {
        Task SendMessageAsync(DiscordMessageDTO message, CancellationToken ct);
    }
}
