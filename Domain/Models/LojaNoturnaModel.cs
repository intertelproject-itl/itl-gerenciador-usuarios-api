using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace itl_gerenciador_usuarios_api.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class LojaNoturnaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }
        [BsonElement("armas")]
        public List<ArmasModel>? Armas { get; set; } = [];
        [BsonElement("armaduras")]
        public List<ArmaduraModel>? Armaduras { get; set; } = [];
        [BsonElement("armas_ciberneticas")]
        public List<ArmasCiberneticasModel>? ArmasCiberneticas { get; set; } = [];
        [BsonElement("ciberneticas")]
        public List<CiberneticasModel>? Ciberneticas { get; set; } = [];
    }
}
