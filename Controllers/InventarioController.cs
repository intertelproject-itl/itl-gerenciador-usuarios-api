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
    }
}
