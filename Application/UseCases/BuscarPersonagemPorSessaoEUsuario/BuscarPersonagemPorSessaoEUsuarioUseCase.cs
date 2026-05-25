using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Ports.Outbound;

namespace itl_gerenciador_usuarios_api.Application.UseCases.BuscarPersonagemPorSessaoEUsuario
{
    public class BuscarPersonagemPorSessaoEUsuarioUseCase : IBuscarPersonagemPorSessaoEUsuarioUseCase
    {
        private readonly IPersonagemOutboundPort _personagemPort;

        public BuscarPersonagemPorSessaoEUsuarioUseCase(IPersonagemOutboundPort personagemPort)
        {
            _personagemPort = personagemPort;
        }

        public Task<PersonagemModel> Execute(long idSessao, long idUsuario, CancellationToken ct)
        {
            return _personagemPort.GetPersonagemBySessaoAndUsuarioAsync(idSessao, idUsuario, ct);
        }
    }
}
