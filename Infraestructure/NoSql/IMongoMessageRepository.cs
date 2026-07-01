using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public interface IMongoMessageRepository
    {
        Task<List<MensagemChatModel>> BuscarEntreHorariosAsync(int idSessao, DateTime horarioInicio, DateTime horarioFim, CancellationToken ct);
        Task InsertAsync(MensagemChatModel item, CancellationToken ct);
    }
}
