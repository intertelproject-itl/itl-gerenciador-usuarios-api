using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface ISessaoJogatinaRepository
    {
        Task<List<SessaoJogatinaModel>> GetSessaoPublicaAsync(CancellationToken ct);
        Task AddAsync(SessaoJogatinaModel sessao, CancellationToken ct);
        Task<SessaoJogatinaModel> GetByIdAsync(long idSessao);
        Task<PersonagemModel> GetPersonagemBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct);
        Task<PersonagemPericiasModel> GetPersonagemPericiasBySessaoAndUsuarioAsync(long idPersonagem, CancellationToken ct);
        Task<PersonagemAtributosModel> GetPersonagemAtributosBySessaoAndUsuarioAsync(long idPersonagem, CancellationToken ct);
    }
}
