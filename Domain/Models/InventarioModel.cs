using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class InventarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("idPersonagem")]
        public int IdPersonagem { get; set; }

        [BsonElement("armas")]
        public List<ArmasModel>? Armas { get; set; }

        [BsonElement("armaduras")]
        public List<ArmaduraModel>? Armaduras { get; set; }

        [BsonElement("ciberneticas")]
        public List<CiberneticasModel>? Ciberneticas { get; set; }

        [BsonElement("armas_ciberneticas")]
        public List<ArmasCiberneticasModel>? ArmasCiberneticas { get; set; }

        [BsonElement("outros")]
        public List<OutrosModel>? Outros { get; set; }

    }

    public class OutrosModel
    {
        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [BsonElement("imagem")]
        public string Imagem { get; set; } = string.Empty;
    }
}
