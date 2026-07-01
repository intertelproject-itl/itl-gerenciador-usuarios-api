using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaNoturnaController(ILojaNoturnaService lojaNoturnaService) : ControllerBase
    {
        private readonly ILojaNoturnaService _lojaNoturnaService = lojaNoturnaService;

        [HttpGet("obterLojaComun")]
        public async Task<ActionResult> GetLojaComun()
        {
            try
            {
                var lojaComun = await _lojaNoturnaService.ObterLojaComun(new CancellationToken());
                return Ok(lojaComun);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("gerarLojaNoturna")]
        public async Task<ActionResult<LojaNoturnaModel>> GerarLojaNoturna([FromQuery] int qtdArmas, [FromQuery] int qtdArmaduras, [FromQuery] int qtdArmasCiberneticas, [FromQuery] int qtdCiberneticas)
        {
            try
            {
                var lojaNoturna = await _lojaNoturnaService.GerarLojaNoturna(qtdArmas, qtdArmaduras, qtdArmasCiberneticas, qtdCiberneticas, new CancellationToken());
                return Ok(lojaNoturna);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterLojaNoturna")]
        public async Task<ActionResult<LojaNoturnaModel>> ObterLojaNoturna()
        {
            try
            {
                var lojaNoturna = await _lojaNoturnaService.ObterLojaNoturna(new CancellationToken());
                return Ok(lojaNoturna);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("comprarItemComum")]
        public async Task<ActionResult> ComprarItemComum([FromBody] ComprarItemDto comprarItemDto)
        {
            try
            {
                await _lojaNoturnaService.ComprarItemComum(comprarItemDto.Categoria, comprarItemDto.IdMongo, comprarItemDto.Valor, comprarItemDto.IdPersonagem, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("comprarLojaNoturna")]
        public async Task<ActionResult> ComprarLojaNoturna([FromBody] ComprarItemDto comprarItemDto)
        {
            try
            {
                await _lojaNoturnaService.ComprarLojaNoturna(comprarItemDto.Categoria, comprarItemDto.IdMongo, comprarItemDto.Valor, comprarItemDto.IdPersonagem, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
