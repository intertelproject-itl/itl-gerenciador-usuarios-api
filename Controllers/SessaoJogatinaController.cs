using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoJogatinaController(ILogger<SessaoJogatinaController> logger,
        ISessaoJogatinaService sessaoJogatinaService) : ControllerBase
    {
        private readonly ILogger<SessaoJogatinaController> _logger = logger;
        private readonly ISessaoJogatinaService _sessaoJogatinaService = sessaoJogatinaService;

        [HttpGet("publicas")]
        public async Task<ActionResult<SessaoJogatinaModel>> BuscarSessoesPublicasAtivas()
        {
            var sessoesPublicas = await _sessaoJogatinaService.BuscarSessaoPublicaAtiva(new CancellationToken());
            return Ok(sessoesPublicas);
        }

        [HttpGet("{idSessao}")]
        public async Task<ActionResult<SessaoJogatinaModel>> BuscarSessao(int idSessao)
        {
            var sessoesAtivas = await _sessaoJogatinaService.BuscarSessaoPorId(idSessao);
            return Ok(sessoesAtivas);
        }

        [HttpGet("{idSessao}/pessoas")]
        public async Task<ActionResult<List<PersonagemModel>>> BuscarPessoasSessao(int idSessao)
        {
            var personagens = await _sessaoJogatinaService.BuscarPersonagensPorSessao(idSessao, new CancellationToken());
            return Ok(personagens);
        }

        [HttpPost("{idSessao}/Acessar")]
        public async Task<ActionResult<SessaoJogatinaModel>> AcessarSessao(int idSessao, int idPersonagem)
        {
            await _sessaoJogatinaService.AcessarAsync(idSessao, idPersonagem);
            return Ok();
        }

        [HttpGet("{idSessao}/{idUsuario}")]
        public async Task<ActionResult<PersonagemModel>> BuscarPersonagemPorSessaoEUsuario(long idSessao, long idUsuario)
        {
            var personagem = await _sessaoJogatinaService.BuscarPersonagemPorSessaoEUsuario(idSessao, idUsuario);
            return Ok(personagem);
        }

        [HttpGet("{idSessao}/pericias/{idPersonagem}")]
        public async Task<ActionResult<PersonagemPericiaDTO>> BuscarPericiasPorSessaoEUsuario(long idPersonagem)
        {
            var pericias = await _sessaoJogatinaService.BuscarPersonagemPericiasPorSessaoEUsuario(idPersonagem);
            return Ok(pericias);
        }

        [HttpGet("{idSessao}/atributos/{idPersonagem}")]
        public async Task<ActionResult<PersonagemAtributosModel>> BuscarAtributosPorSessaoEUsuario(long idPersonagem)
        {
            var atributos = await _sessaoJogatinaService.BuscarPersonagemAtributosPorSessaoEUsuario(idPersonagem);
            return Ok(atributos);
        }

        [HttpPost("{idSessao}/chat/{NomePersonagem}")]
        public async Task<ActionResult> EnviarMensageChat(long idSessao, string nomePersonagem, string mensagem)
        {
            try
            {
                await _sessaoJogatinaService.NovaMensagem(new MensagemChatModel
                {
                    DataCriacao = DateTime.Now,
                    IdSessao = (int)idSessao,
                    Mensagem = mensagem,
                    NomePersonagem = nomePersonagem
                });
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }

        [HttpPost("{idSessao}/chat-async/{NomePersonagem}")]
        public async Task<ActionResult> EnviarMensageChatAsync(long idSessao, string nomePersonagem, string mensagem, CancellationToken cancellationToken)
        {
            try
            {
                await _sessaoJogatinaService.NovaMensagemAsync(new MensagemChatModel
                {
                    DataCriacao = DateTime.Now,
                    IdSessao = (int)idSessao,
                    Mensagem = mensagem,
                    NomePersonagem = nomePersonagem
                }, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("{idSessao}/chat")]
        public async Task<ActionResult<List<MensagemChatModel>>> CarregarChat(int idSessao)
        {
            return await _sessaoJogatinaService.CarregarChat(idSessao);
        }
    }
}
