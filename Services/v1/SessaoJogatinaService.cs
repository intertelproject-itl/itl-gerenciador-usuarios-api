using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class SessaoJogatinaService : ISessaoJogatinaService
    {
        private readonly ILogger<SessaoJogatinaService> _logger;
        private readonly ISessaoJogatinaRepository _sessaoJogatinaRepository;

        public SessaoJogatinaService(ILogger<SessaoJogatinaService> logger,
            ISessaoJogatinaRepository sessaoJogatinaRepository)
        {
            _logger = logger;
            _sessaoJogatinaRepository = sessaoJogatinaRepository;
        }

        public async Task<List<SessaoJogatinaModel>> BuscarSessaoPublicaAtiva(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando sessões de jogatina ativas...");
            return await _sessaoJogatinaRepository.GetSessaoPublicaAsync(cancellationToken);
        }

        public async Task<SessaoJogatinaModel> BuscarSessaoPorId(long idSessao)
        {
            _logger.LogInformation($"Buscando sessão de jogatina com ID: {idSessao}...");
            return await _sessaoJogatinaRepository.GetByIdAsync(idSessao);
        }

        public async Task<List<PersonagemModel>> BuscarPersonagensPorSessao(long idSessao, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Buscando personagens para sessão de jogatina com ID: {idSessao}...");
            return await _sessaoJogatinaRepository.GetPessoasSessaoAsync(idSessao, cancellationToken);
        }

        public async Task AcessarAsync(long idSessao, long idPersonagem)
        {
            _logger.LogInformation($"Acessando sessão de jogatina...");
            await _sessaoJogatinaRepository.AcessarSessao(idSessao, idPersonagem, new CancellationToken());
        }

        public async Task<PersonagemModel> BuscarPersonagemPorSessaoEUsuario(long idSessao, long idUsuario)
        {
            return await _sessaoJogatinaRepository.GetPersonagemBySessaoAndUsuarioAsync(idSessao, idUsuario, new CancellationToken());
        }

        public async Task<PersonagemPericiasModel> BuscarPersonagemPericiasPorSessaoEUsuario(long idPersonagem)
        {
            return await _sessaoJogatinaRepository.GetPersonagemPericiasBySessaoAndUsuarioAsync(idPersonagem, new CancellationToken());
        }

        public async Task<PersonagemAtributosModel> BuscarPersonagemAtributosPorSessaoEUsuario(long idPersonagem)
        {
            return await _sessaoJogatinaRepository.GetPersonagemAtributosBySessaoAndUsuarioAsync(idPersonagem, new CancellationToken());
        }
    }
}
