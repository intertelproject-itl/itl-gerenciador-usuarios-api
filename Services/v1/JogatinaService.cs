using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class JogatinaService(IPersonagemRepository personagemRepository, SignalRService signalRService) : ServiceBase(signalRService), IJogatinaService
    {
        private readonly IPersonagemRepository _personagemRepository = personagemRepository;

        public async Task AtualizarDadosMaximoAsync(int idPersonagem, int hpMaximo = 0, int protecaoMaxima = 0, int sorteMaxima = 0, int humanidade = 0, CancellationToken ct = default)
        {
            await _personagemRepository.AtualizarDadosPersonagemAsync(idPersonagem, hpMaximo, protecaoMaxima, humanidade, sorteMaxima, ct);
            await   _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task InfligirDanoAsync(int idPersonagem, int danoHp = 0, int danoProtecao = 0, int danoSorte = 0, int humanidade = 0, CancellationToken ct = default)
        {
            await _personagemRepository.InfligirDanoAsync(idPersonagem, danoHp, danoProtecao, danoSorte, humanidade, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task InfligirFerimentosCriticosAsync(int idPersonagem, string ferimento = "", CancellationToken ct = default)
        {
            await _personagemRepository.InfligirFerimentoCriticoAsync(idPersonagem, ferimento, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task CurarFerimentosCriticosAsync(int idPersonagem, string ferimento = "", bool curarTodos = false, CancellationToken ct = default)
        {
            await _personagemRepository.CurarFerimentoAsync(idPersonagem, ferimento, curarTodos, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task CurarHpAsync(int idPersonagem, int hpCurado = 0, bool hpTotal = false, CancellationToken ct = default)
        {
            await _personagemRepository.CurarHpMaximoAsync(idPersonagem, hpCurado, hpTotal, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task CurarProtecaoArmaduraMaximaAsync(int idPersonagem, int protecaoCurada = 0, bool protecaoTotal = false, CancellationToken ct = default)
        {
            await _personagemRepository.CurarProtecaoArmaduraMaximaAsync(idPersonagem, protecaoCurada, protecaoTotal, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);    
        }

        public async Task CurarSorteAsync(int idPersonagem, int sorteCurada = 0, bool sorteTotal = false, CancellationToken ct = default)
        {
            await _personagemRepository.CurarSorteMaximaAsync(idPersonagem, sorteCurada, sorteTotal, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task CurarHumanidadeAsync(int idPersonagem, int humanidadeCurada = 0, bool humanidadeTotal = false, CancellationToken ct = default)
        {
            await _personagemRepository.CurarHumanidadeMaximaAsync(idPersonagem, humanidadeCurada, humanidadeTotal, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }
    }
}