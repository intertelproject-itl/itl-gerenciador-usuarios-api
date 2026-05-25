using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace itl_gerenciador_usuarios_api.Infraestructure.NoSql
{
    public class SessaoMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int IdSessaoRelacional { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
