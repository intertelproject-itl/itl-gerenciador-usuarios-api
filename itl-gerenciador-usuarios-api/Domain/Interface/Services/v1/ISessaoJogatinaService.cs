using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface ISessaoJogatinaService
    {
        Task<List<SessaoJogatinaModel>> BuscarSessaoPublicaAtiva(CancellationToken cancellationToken);
        Task<SessaoJogatinaModel> BuscarSessaoPorId(long idSessao);
        Task<PersonagemModel> BuscarPersonagemPorSessaoEUsuario(long idSessao, long idUsuario);
        Task<PersonagemPericiasModel> BuscarPersonagemPericiasPorSessaoEUsuario(long idPersonagem);
        Task<PersonagemAtributosModel> BuscarPersonagemAtributosPorSessaoEUsuario(long idPersonagem);
    }
}
