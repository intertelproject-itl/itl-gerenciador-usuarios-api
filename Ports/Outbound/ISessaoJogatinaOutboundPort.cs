using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Ports.Outbound
{
    public interface ISessaoJogatinaOutboundPort
    {
        Task<List<SessaoJogatinaModel>> GetSessaoPublicaAsync(CancellationToken ct);
        Task<SessaoJogatinaModel> GetByIdAsync(long idSessao);
        Task AddAsync(SessaoJogatinaModel sessao, CancellationToken ct);
    }
}
