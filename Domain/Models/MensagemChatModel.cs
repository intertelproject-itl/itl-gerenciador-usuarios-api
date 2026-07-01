using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    public class MensagemChatModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("IdSessao")]
        public int IdSessao { get; set; }

        [BsonElement("nomePersonagem")]
        public string NomePersonagem { get; set; } = string.Empty;

        [BsonElement("Mensagem")]
        public string Mensagem { get; set; } = string.Empty;

        [BsonElement("DataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
