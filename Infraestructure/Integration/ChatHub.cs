namespace itl_gerenciador_usuarios_api.Infraestructure.Integration
{
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {
        public async Task EntrarNaSessao(int idSessao)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, idSessao.ToString());
        }

        public async Task SairDaSessao(int idSessao)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, idSessao.ToString());
        }
    }
}
