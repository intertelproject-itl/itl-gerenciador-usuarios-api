using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Ports.Outbound
{
    public interface IPersonagemOutboundPort
    {
        Task<PersonagemModel> GetPersonagemBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct);
        Task<PersonagemPericiasModel> GetPersonagemPericiasBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct);
        Task<PersonagemAtributosModel> GetPersonagemAtributosBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct);
    }
}
