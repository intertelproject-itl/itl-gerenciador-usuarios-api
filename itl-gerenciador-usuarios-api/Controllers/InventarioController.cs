using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController(IInventarioService inventarioService) : ControllerBase
    {
        private readonly IInventarioService _inventarioService = inventarioService;

    }
}
