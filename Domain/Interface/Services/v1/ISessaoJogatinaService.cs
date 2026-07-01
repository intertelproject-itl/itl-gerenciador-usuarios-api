using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface ISessaoJogatinaService
    {
        Task<List<SessaoJogatinaModel>> BuscarSessaoPublicaAtiva(CancellationToken cancellationToken);
        Task<SessaoJogatinaModel> BuscarSessaoPorId(long idSessao);
        Task<List<PersonagemModel>> BuscarPersonagensPorSessao(long idSessao, CancellationToken cancellationToken);
        Task<PersonagemModel> BuscarPersonagemPorSessaoEUsuario(long idSessao, long idUsuario);
        Task<PersonagemPericiaDTO> BuscarPersonagemPericiasPorSessaoEUsuario(long idPersonagem);
        Task<PersonagemAtributosModel> BuscarPersonagemAtributosPorSessaoEUsuario(long idPersonagem);
        Task<List<MensagemChatModel>> CarregarChat(int idSessao);
        Task NovaMensagem(MensagemChatModel mensagem);

        Task AcessarAsync(long idSessao, long idPersonagem);        
    }
}
