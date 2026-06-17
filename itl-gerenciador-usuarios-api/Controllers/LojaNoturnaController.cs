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

        [HttpGet("armas")]
        public async Task<ActionResult<List<ArmasModel>>> ObterTodasArmas()
        {
            try
            {
                var armas = await _lojaNoturnaService.ObterTodasArmas(new CancellationToken());
                return Ok(armas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("armaduras")]
        public async Task<ActionResult<List<ArmaduraModel>>> ObterTodasArmaduras()
        {
            try
            {
                var armaduras = await _lojaNoturnaService.ObterTodasArmaduras(new CancellationToken());
                return Ok(armaduras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("armas-ciberneticas")]
        public async Task<ActionResult<List<ArmasCiberneticasModel>>> ObterTodasArmasCiberneticas()
        {
            try
            {
                var armasCiberneticas = await _lojaNoturnaService.ObterTodasArmasCiberneticas(new CancellationToken());
                return Ok(armasCiberneticas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ciberneticas")]
        public async Task<ActionResult<List<CiberneticasModel>>> ObterTodasCiberneticas()
        {
            try
            {
                var ciberneticas = await _lojaNoturnaService.ObterTodasCiberneticas(new CancellationToken());
                return Ok(ciberneticas);
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

    }
}
