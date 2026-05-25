using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Integrations;
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
        [HttpPost]
        public async Task<IActionResult> Send([FromBody] InventarioModel model)
        {
            try
            {
                await _inventarioService.AdicionarItem(model, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<InventarioModel>> Get(string idPersonagem)
        {
            try
            {
                var itens = await _inventarioService.ObterItens(idPersonagem, new CancellationToken());
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
