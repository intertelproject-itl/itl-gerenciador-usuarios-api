using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public interface IMongoInventarioRepository<T>
    {
        Task InsertAsync(T item, CancellationToken ct);
        Task<T?> GetByIdAsync(string chave, string valor, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task UpdateAsync(string id, T item, CancellationToken ct);
        Task DeleteAsync(string id, CancellationToken ct);
    }
}
