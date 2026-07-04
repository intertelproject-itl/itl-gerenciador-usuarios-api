using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class SessaoJogatinaService : ServiceBase, ISessaoJogatinaService
    {
        private readonly ILogger<SessaoJogatinaService> _logger;
        private readonly ISessaoJogatinaRepository _sessaoJogatinaRepository;
        private readonly IPersonagemPericiaRepository _personagemPericiaRepository;
        private readonly IMongoMessageRepository _repositoryChat;
        private readonly Dictionary<string, List<string>> _periciasPorAtributo;

        public SessaoJogatinaService(ILogger<SessaoJogatinaService> logger,
            IPersonagemPericiaRepository personagemPericiaRepository,
            ISessaoJogatinaRepository sessaoJogatinaRepository,
            IMongoMessageRepository repositorioChat,
            SignalRService signalR,
            IConfiguration configuration) : base(signalR)
        {
            _logger = logger;
            _personagemPericiaRepository = personagemPericiaRepository;
            _repositoryChat = repositorioChat;
            _sessaoJogatinaRepository = sessaoJogatinaRepository;
            _periciasPorAtributo = configuration.GetSection("SpecialValidation:Pericias").Get<Dictionary<string, List<string>>>() ?? throw new Exception("Configuração de validação especial para 'Pericias' não encontrada.");
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

        public async Task<PersonagemPericiaDTO> BuscarPersonagemPericiasPorSessaoEUsuario(long idPersonagem)
        {
            // Buscar as perícias do personagem
            PersonagemPericiaDTO personagemPericias = new();
            personagemPericias.PericiasLuta = await _personagemPericiaRepository.GetPericiasLutaByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasAtencao = await _personagemPericiaRepository.GetPericiasAtencaoByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasConducao = await _personagemPericiaRepository.GetPericiasConducaoByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasCorporais = await _personagemPericiaRepository.GetPericiasCorporaisByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasEducacao = await _personagemPericiaRepository.GetPericiasEducacaoByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasPerformance = await _personagemPericiaRepository.GetPericiasPerformanceByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasSociais = await _personagemPericiaRepository.GetPericiasSociaisByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasTecnicas = await _personagemPericiaRepository.GetPericiasTecnicasByIdPersonagemAsync(idPersonagem, new CancellationToken());
            personagemPericias.PericiasArmas = await _personagemPericiaRepository.GetPericiasArmasByIdPersonagemAsync(idPersonagem, new CancellationToken());

            // Buscar os atributos do personagem
            PersonagemAtributosModel personagemAtributos = await _sessaoJogatinaRepository.GetPersonagemAtributosByPersonagemIdAsync(idPersonagem, new CancellationToken());

            // Aplicar os atributos base às perícias
            var valoresAtributos = new Dictionary<string, int>
            {
                ["int"] = personagemAtributos.Inteligencia,
                ["fvo"] = personagemAtributos.Vontade,
                ["des"] = personagemAtributos.Destreza,
                ["ref"] = personagemAtributos.Reflexos,
                ["cool"] = personagemAtributos.Frieza,
                ["emp"] = personagemAtributos.Empatia,
                ["tec"] = personagemAtributos.Tecnica
            };

            // Aplicar os atributos base às perícias
            personagemPericias.PericiasArmas.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasLuta.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasAtencao.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasConducao.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasCorporais.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasEducacao.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasPerformance.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasSociais.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);
            personagemPericias.PericiasTecnicas.AplicarAtributosBase(_periciasPorAtributo, valoresAtributos);

            return personagemPericias;
        }

        public async Task<PersonagemAtributosModel> BuscarPersonagemAtributosPorSessaoEUsuario(long idPersonagem)
        {
            return await _sessaoJogatinaRepository.GetPersonagemAtributosByPersonagemIdAsync(idPersonagem, new CancellationToken());
        }

        public async Task<List<MensagemChatModel>> CarregarChat(int idSessao)
        {
            return await _repositoryChat.BuscarEntreHorariosAsync(idSessao, DateTime.Now.AddMinutes(-30), DateTime.Now, new CancellationToken());
        }

        public async Task NovaMensagemAsync(MensagemChatModel mensagem, CancellationToken cancellationToken)
        {
            await _signalRService.EnviarMensagemChat(mensagem.IdSessao, mensagem.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"), mensagem.NomePersonagem, mensagem.Mensagem);
            await _repositoryChat.InsertAsync(mensagem, cancellationToken);
        }

        public async Task NovaMensagem(MensagemChatModel mensagem)
        {
            await _signalRService.EnviarMensagemChat(mensagem.IdSessao, mensagem.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss"), mensagem.NomePersonagem, mensagem.Mensagem);
            await _repositoryChat.InsertAsync(mensagem, new CancellationToken());
        }

        public async Task AtualizaSituacaoLojaNoturna(int idSessao, int situacao)
        {
            await _sessaoJogatinaRepository.AtualizarSituacaoLojaNoturna(idSessao, situacao);
            if (situacao == 1)
            {
                await _signalRService.LigarLojaNoturna(idSessao);

            }
            else
            {
                await _signalRService.DesligarLojaNoturna(idSessao);
            }
        }

        public async Task AtualizaSituacaoLojaComum(int idSessao, int situacao)
        {
            await _sessaoJogatinaRepository.AtualizarSituacaoLojaComum(idSessao, situacao);
            if (situacao == 1)
            {
                await _signalRService.LigarLojaComun(idSessao);
            }
            else
            {
                await _signalRService.DesligarLojaComun(idSessao);
            }
        }
    }
}
