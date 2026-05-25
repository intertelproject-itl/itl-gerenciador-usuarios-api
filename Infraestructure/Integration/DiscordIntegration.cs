using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using itl_gerenciador_usuarios_api.Domain.Dto;
using Microsoft.Extensions.Options;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    public class DiscordIntegration
    {
        private readonly DiscordSettings _settings;
        private readonly HttpClient _http;

        public DiscordIntegration(IOptions<DiscordSettings> options, HttpClient http)
        {
            _settings = options?.Value ?? new DiscordSettings();
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public virtual async Task SendMessageAsync(DiscordMessageDTO message, CancellationToken ct)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(_settings?.WebhookUrl))
                throw new InvalidOperationException("Discord webhook not configured");

            var payload = new { content = $"**{message.Nome}** ({message.Funcao}): {message.Dado}" };
            var json = JsonSerializer.Serialize(payload);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _http.PostAsync(_settings.WebhookUrl, content, ct).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
        }
    }
}
