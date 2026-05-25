using Google.Protobuf;
using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Integrations;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    public class DiscordIntegration : IDiscordIntegration
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

            var payload = new
            {
                content = "📡 Nova transmissão INTERTEL detectada...",
                embeds = new[]
            {
                    new
                    {
                        title = "🔻 INTERTEL // DICE LOG",
                        description =
                        $"> {EmojiExibicao(message.TipoDado, message.Dado)}\n" +
                        $"> **Dice Type**: `{message.TipoDado}`\n" +
                        $"> **Operador:** `{message.Nome}`\n" +
                        $"> **Função:** `{message.Funcao}`\n" +
                        $"> **Resultado:** 🎲 ** {message.Dado} **\n" +
                        ExibirModificador(message.Modificadores)
                       ,
                        color = CorExibicao(message.TipoDado, message.Dado)
                    }

                }
            };

            var json = JsonSerializer.Serialize(payload);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await _http.PostAsync(_settings.WebhookUrl, content, ct).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
        }

        private int CorExibicao(string tipoDado, string valorDado)
        {
            int tipoDadoInt = Convert.ToInt32(tipoDado.Substring(1, tipoDado.Count() - 1));
            int valorDadoInt = Convert.ToInt32(valorDado);

            if (valorDadoInt == 1)
                return 0xFF003C;
            if (tipoDadoInt == valorDadoInt)
                return 0x39FF14;

            return 0xFCEE09;

        }

        private string EmojiExibicao(string tipoDado, string valorDado)
        {
            int tipoDadoInt = Convert.ToInt32(tipoDado.Substring(1, tipoDado.Count() - 1));
            int valorDadoInt = Convert.ToInt32(valorDado);
            if (valorDadoInt == 1)
                return " ❌";
            if (tipoDadoInt == valorDadoInt)
                return "✅ ";
            return "⚠️ ";


        }

        private string ExibirModificador(string modificador)
        {
            return modificador != string.Empty ?
                $"> **Modificadores:** `{modificador}`" :
                string.Empty;
        }
    }

}
