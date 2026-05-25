using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public interface IMongoRepository<T>
    {
        Task InsertAsync(T item, CancellationToken ct);
        Task<T?> GetByIdAsync(string id, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task UpdateAsync(string id, T item, CancellationToken ct);
        Task DeleteAsync(string id, CancellationToken ct);
    }
}
