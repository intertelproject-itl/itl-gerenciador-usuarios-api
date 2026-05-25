using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpGet]
        public async Task<ActionResult<UsuarioModel>> ObterRegistroPorId([FromQuery] int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id, new CancellationToken());
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                await _usuarioService.AddAsync(usuario, new CancellationToken());
                return Ok("Usuario criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listar")]
        async public Task<ActionResult<List<UsuarioModel>>> ListarRegistros()
        {
            try
            {
                var usuarios = await _usuarioService.ListAsync(new CancellationToken());
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
