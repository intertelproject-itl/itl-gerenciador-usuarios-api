using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    public class JogatinaController(IJogatinaService jogatinaService) : ControllerBase
    {
        private readonly IJogatinaService _jogatinaService = jogatinaService;

        [HttpPut("AtualizaDadosMaximo")]
        public async Task<IActionResult> AtualizarDadosMaximoAsync(int idPersonagem, int hpMaximo = 0, int protecaoMaxima = 0, int sorteMaxima = 0, int humanidade = 0)
        {
            try
            {
                await _jogatinaService.AtualizarDadosMaximoAsync(idPersonagem, hpMaximo, protecaoMaxima, sorteMaxima, humanidade, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("InfligirDano")]
        public async Task<IActionResult> InfligirDanoAsync(int idPersonagem, int danoHp = 0, int danoProtecao = 0, int danoSorte = 0, int humanidade = 0)
        {
            try
            {
                await _jogatinaService.InfligirDanoAsync(idPersonagem, danoHp, danoProtecao, danoSorte, humanidade, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("InfligirFerimentosCriticos")]
        public async Task<IActionResult> InfligirFerimentosCriticosAsync(int idPersonagem, string ferimento = "")
        {
            try
            {
                await _jogatinaService.InfligirFerimentosCriticosAsync(idPersonagem, ferimento, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CurarFerimentosCriticos")]
        public async Task<IActionResult> CurarFerimentosCriticosAsync(int idPersonagem, string ferimento = "", bool curarTodos = false)
        {
            try
            {
                await _jogatinaService.CurarFerimentosCriticosAsync(idPersonagem, ferimento, curarTodos, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CurarHp")]
        public async Task<IActionResult> CurarHpAsync(int idPersonagem, int hpCurado = 0, bool hpTotal = false)
        {
            try
            {
                await _jogatinaService.CurarHpAsync(idPersonagem, hpCurado, hpTotal, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CurarProtecaoArmaduraMaxima")]
        public async Task<IActionResult> CurarProtecaoArmaduraMaximaAsync(int idPersonagem, int protecaoCurada = 0, bool protecaoTotal = false)
        {
            try
            {
                await _jogatinaService.CurarProtecaoArmaduraMaximaAsync(idPersonagem, protecaoCurada, protecaoTotal, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CurarSorte")]
        public async Task<IActionResult> CurarSorteAsync(int idPersonagem, int sorteCurada = 0, bool sorteTotal = false)
        {
            try
            {
                await _jogatinaService.CurarSorteAsync(idPersonagem, sorteCurada, sorteTotal, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("CurarHumanidade")]
        public async Task<IActionResult> CurarHumanidadeAsync(int idPersonagem, int humanidadeCurada = 0, bool humanidadeTotal = false)
        {
            try
            {
                await _jogatinaService.CurarHumanidadeAsync(idPersonagem, humanidadeCurada, humanidadeTotal, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
