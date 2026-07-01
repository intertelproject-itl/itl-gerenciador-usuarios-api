using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var dbName = settings?.Value?.Database ?? "itl_app";
            var db = client.GetDatabase(dbName);
            // use the type name as collection name by convention
            var collectionName = typeof(T).Name.Replace("Model", "");
            _collection = db.GetCollection<T>(collectionName);
        }

        public async Task InsertAsync(T item, CancellationToken ct)
        {
            await _collection.InsertOneAsync(item, cancellationToken: ct);


        }        

        public async Task<T?> GetByChaveAsync(string chave, string valor, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq(chave, Convert.ToInt32(valor));
            var res = await _collection.Find(filter).FirstOrDefaultAsync(ct);
            return res;
        }

        public async Task<List<T?>> GetListByChaveAsync(string chave, string valor, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq(chave, valor);
            var res = await _collection.Find(filter).ToListAsync(ct);
            return res;
        }

        public async Task<T?> GetByIdAsync(string id, CancellationToken ct)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            var res = await _collection.Find(filter).FirstOrDefaultAsync(ct);
            return res;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
        {
            var res = await _collection.Find(Builders<T>.Filter.Empty).ToListAsync(ct);
            return res;
        }

        public async Task<T> GetFirstOrDefaultAsync(CancellationToken ct)
        {
            var res = await _collection.Find(Builders<T>.Filter.Empty).FirstOrDefaultAsync(ct);
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
