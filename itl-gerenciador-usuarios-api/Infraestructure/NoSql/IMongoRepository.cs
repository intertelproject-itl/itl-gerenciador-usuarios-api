namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public interface IMongoRepository<T>
    {
        Task InsertAsync(T item, CancellationToken ct);
        Task<List<T>?> GetByPersoangemIdAsync(string chave, string valor, CancellationToken ct);
        Task<T?> GetByIdAsync(string id, CancellationToken ct);
        Task<T> GetFirstOrDefaultAsync(CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task UpdateAsync(string id, T item, CancellationToken ct);
        Task DeleteAsync(string id, CancellationToken ct);
    }
}
