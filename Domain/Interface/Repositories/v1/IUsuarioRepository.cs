using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel?> GetByEmailAsync(string email, CancellationToken ct);
        Task<UsuarioModel?> GetByIdAsync(int id, CancellationToken ct);
        Task<List<UsuarioModel>> ListAsync(CancellationToken ct);
        Task AddAsync(UsuarioModel cliente, CancellationToken ct);
    }
}
