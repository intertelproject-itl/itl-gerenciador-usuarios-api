using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Services.v1.Encrypt;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class LoginService(IUsuarioService usuarioService, JwtTokenService jwtTokenService) : ILoginService
    {
        private readonly JwtTokenService _jwtTokenService = jwtTokenService;
        private readonly IUsuarioService _usuarioService = usuarioService;

        public LoginResponseDTO GerarToken(LoginRequestDTO login, CancellationToken ct)
        {
            var usuario = _usuarioService.AutenticarAsync(login.Email, login.Password, ct).Result;
            return usuario is null
                ? throw new UnauthorizedAccessException("Email ou senha inválidos.")
                : _jwtTokenService.GerarToken(usuario);
        }

        public LoginResponseDTO CriarConta(UsuarioDTO registro, CancellationToken ct)
        {
            _usuarioService.AddAsync(registro, ct).Wait();
            var usuario = _usuarioService.AutenticarAsync(registro.Email, registro.Password, ct).Result;
            return usuario is null
               ? throw new UnauthorizedAccessException("Erro inesperado, por favor tente mais tarde.")
               : _jwtTokenService.GerarToken(usuario);
        }
    }
}
