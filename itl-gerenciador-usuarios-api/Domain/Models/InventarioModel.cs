using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class InventarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int IdPersonagem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Base64 { get; set; } = string.Empty;
        public string CaminhoImagem { get; set; } = string.Empty;
    }
}
