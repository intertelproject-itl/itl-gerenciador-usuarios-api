using MongoDB.Bson;
using MongoDB.Driver;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public class MongoInventarioRepository<T> : IMongoInventarioRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoInventarioRepository(IMongoClient client, string database, string collectionName)
        {
            var db = client.GetDatabase(database);
            _collection = db.GetCollection<T>(collectionName);
        }

        public async Task InsertAsync(T item, CancellationToken ct)
        {
            await _collection.InsertOneAsync(item, cancellationToken: ct);
        }

        public async Task<T?> GetByIdAsync(string chave, string valor, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq(chave, valor);
            var res = await _collection.Find(filter).FirstOrDefaultAsync(ct);
            return res;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
        {
            var res = await _collection.Find(Builders<T>.Filter.Empty).ToListAsync(ct);
            return res;
        }

        public async Task UpdateAsync(string id, T item, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await _collection.ReplaceOneAsync(filter, item, cancellationToken: ct);
        }

        public async Task DeleteAsync(string id, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await _collection.DeleteOneAsync(filter, ct);
        }
    }
}
