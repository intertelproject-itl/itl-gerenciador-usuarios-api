using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;

        [HttpPost]
        public ActionResult<LoginResponseDTO> Login(LoginRequestDTO login)
        {
            try
            {
                return Ok(_loginService.GerarToken(login, new CancellationToken()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastrar")]
        public ActionResult<LoginResponseDTO> CriarConta(UsuarioDTO usuario)
        {
            try
            {
                return Ok(_loginService.CriarConta(usuario, new CancellationToken()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
