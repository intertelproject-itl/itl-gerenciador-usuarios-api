using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface ISessaoJogatinaRepository
    {
        Task<List<SessaoJogatinaModel>> GetSessaoPublicaAsync(CancellationToken ct);
        Task AddAsync(SessaoJogatinaModel sessao, CancellationToken ct);
        Task<SessaoJogatinaModel> GetByIdAsync(long idSessao);
        Task AcessarSessao(long idSessao, long idPersonagem, CancellationToken ct);
        Task<List<PersonagemModel>> GetPessoasSessaoAsync(long idSessao, CancellationToken ct);
        Task<PersonagemModel> GetPersonagemBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct);
        Task<PersonagemPericiasModel> GetPersonagemPericiasBySessaoAndUsuarioAsync(long idPersonagem, CancellationToken ct);
        Task<PersonagemAtributosModel> GetPersonagemAtributosByPersonagemIdAsync(long idPersonagem, CancellationToken ct);
    }
}
