using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Application.UseCases.BuscarPersonagemPorSessaoEUsuario
{
    public interface IBuscarPersonagemPorSessaoEUsuarioUseCase
    {
        Task<PersonagemModel> Execute(long idSessao, long idUsuario, CancellationToken ct);
    }
}
