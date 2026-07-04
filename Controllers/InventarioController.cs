using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController(IInventarioService inventarioService) : ControllerBase
    {
        private readonly IInventarioService _inventarioService = inventarioService;

        [HttpGet("{idPersonagem}")]
        public ActionResult<List<InventarioModel>> BuscarInventarioPorPersonagem(int idPersonagem)
        {
            var inventario = _inventarioService.BuscarInventarioPorPersonagem(idPersonagem);
            return Ok(inventario);
        }

        [HttpPost("InserirNovoOutroItem")]
        public async Task<ActionResult> InserirNovoOutroItem(OutrosModel outroItem, IFormFile imagem)
        {
            await _inventarioService.InserirNovoItem(outroItem, imagem, CancellationToken.None);
            return Ok();
        }

        [HttpPost("InserirNovaArmaItem")]
        public async Task<ActionResult> InserirNovaArmaItem(ArmasModel arma)
        {
            await _inventarioService.InserirNovoItem(arma, null, CancellationToken.None);
            return Ok();
        }

        [HttpPost("InserirNovaArmaduraItem")]
        public async Task<ActionResult> InserirNovaArmaduraItem(ArmaduraModel armadura)
        {
            await _inventarioService.InserirNovoItem(armadura, null, CancellationToken.None);
            return Ok();
        }

        [HttpPost("InserirNovaCiberneticaItem")]
        public async Task<ActionResult> InserirNovaCiberneticaItem(CiberneticasModel cibernetica)
        {
            await _inventarioService.InserirNovoItem(cibernetica, null, CancellationToken.None);
            return Ok();
        }

        [HttpPost("InserirNovaArmaCiberneticaItem")]
        public async Task<ActionResult> InserirNovaArmaCiberneticaItem(ArmasCiberneticasModel armaCibernetica)
        {
            await _inventarioService.InserirNovoItem(armaCibernetica, null, CancellationToken.None);
            return Ok();
        }

        [HttpPost("PassarItem/{idPersonagemOrigem}/{idPersonagemDestino}")]
        public async Task<ActionResult> PassarItem(string idItem, bool duplicavel, int idPersonagemOrigem, int idPersonagemDestino)
        {
            await _inventarioService.PassarItemAsync(idItem, duplicavel, idPersonagemOrigem, idPersonagemDestino, CancellationToken.None);
            return Ok();
        }
    }
}