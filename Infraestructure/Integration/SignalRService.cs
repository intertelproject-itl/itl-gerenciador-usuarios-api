using Microsoft.AspNetCore.SignalR;

namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    public class SignalRService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task AtualizarFicha(int idSessao, int idPersonagem)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizaFicha", idPersonagem);
        }

        public async Task AtualizarPericia(int idSessao, int idPersonagem)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizaPericia", idPersonagem);
        }

        public async Task AtualizarAtributos(int idSessao, int idPersonagem)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizaAtributos", idPersonagem);
        }

        public async Task AtualizarInventario(int idSessao, int idPersonagem)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizaInventario", idPersonagem);
        }

        public async Task LigarLojaNoturna(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("LigarLojaNoturna", idSessao);
        }

        public async Task DesligarLojaNoturna(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("DesligarLojaNoturna", idSessao);
        }

        public async Task AtualizarLojaNoturna(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizarLojaNoturna", idSessao);
        }

        public async Task LigarLojaComun(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("LigarLojaComun", idSessao);
        }

        public async Task DesligarLojaComun(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("DesligarLojaComun", idSessao);
        }

        public async Task AtualizarLojaComun(int idSessao)
        {
            await _hubContext.Clients
                .All
                .SendAsync("AtualizarLojaComun", idSessao);
        }

        public async Task EnviarMensagemChat(int idSessao, string dataHora, string nomePersonagem, string mensagem)
        {
            await _hubContext.Clients
                .All
                .SendAsync("NovaMensagem", idSessao, dataHora, nomePersonagem, mensagem);
        }
    }
}
