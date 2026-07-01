using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public class MongoMessageRepository : IMongoMessageRepository
    {
        private readonly IMongoCollection<MensagemChatModel> _collection;

        public MongoMessageRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var dbName = settings?.Value?.Database ?? "itl_app";
            var db = client.GetDatabase(dbName);
            // use the type name as collection name by convention
            var collectionName = typeof(MensagemChatModel).Name.Replace("Model", "");
            _collection = db.GetCollection<MensagemChatModel>(collectionName);
        }

        public async Task InsertAsync(MensagemChatModel item, CancellationToken ct)
        {
            await _collection.InsertOneAsync(item, cancellationToken: ct);
        }

        public async Task<List<MensagemChatModel>> BuscarEntreHorariosAsync(int idSessao, DateTime horarioInicio, DateTime horarioFim, CancellationToken ct)
        {
            var filtro = Builders<MensagemChatModel>.Filter.And(
                Builders<MensagemChatModel>.Filter.Gte(x => x.DataCriacao, horarioInicio),
                Builders<MensagemChatModel>.Filter.Lte(x => x.DataCriacao, horarioFim),
                Builders<MensagemChatModel>.Filter.Eq("IdSessao", idSessao)
            );

            return await _collection
                .Find(filtro)
                .ToListAsync(ct);
        }
    }
}