using itl_gerenciador_usuarios_api.Domain.Dto;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface ILoginService
    {
        LoginResponseDTO GerarToken(LoginRequestDTO login, CancellationToken ct);
        LoginResponseDTO CriarConta(UsuarioDTO registro, CancellationToken ct);
    }
}
