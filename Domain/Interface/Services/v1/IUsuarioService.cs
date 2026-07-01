using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IUsuarioService
    {
        Task<UsuarioModel?> GetByIdAsync(int id, CancellationToken ct);
        Task<List<UsuarioModel>> ListAsync(CancellationToken ct);
        Task AddAsync(UsuarioDTO usuario, CancellationToken ct);
        Task<UsuarioModel?> AutenticarAsync(string email, string password, CancellationToken ct);

    }
}
