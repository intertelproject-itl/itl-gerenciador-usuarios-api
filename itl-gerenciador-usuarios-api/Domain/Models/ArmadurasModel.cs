namespace itl_gerenciador_usuarios_api.Domain.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class ArmaduraModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("pa")]
        public int Pa { get; set; }

        [BsonElement("penalidade")]
        public string Penalidade { get; set; } = string.Empty;

        [BsonElement("cobertura")]
        public string Cobertura { get; set; } = string.Empty;

        [BsonElement("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [BsonElement("preco")]
        public int Preco { get; set; }

        [BsonElement("detalhe")]
        public string Detalhe { get; set; } = string.Empty;

        [BsonElement("raridade")]
        public string Raridade { get; set; } = string.Empty;

        [BsonElement("observacao")]
        public string Observacao { get; set; } = string.Empty;
    }
}