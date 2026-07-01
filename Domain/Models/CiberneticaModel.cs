namespace itl_gerenciador_usuarios_api.Domain.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class CiberneticasModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [BsonElement("categoria")]
        public string Categoria { get; set; } = string.Empty;

        [BsonElement("slot")]
        public string Slot { get; set; } = string.Empty;

        [BsonElement("custoHumanidade")]
        public string CustoHumanidade { get; set; } = string.Empty;

        [BsonElement("detalhe")]
        public string Detalhe { get; set; } = string.Empty;

        [BsonElement("pericia")]
        public string Pericia { get; set; } = string.Empty;

        [BsonElement("preco")]
        public int Preco { get; set; }

        [BsonElement("raridade")]
        public string Raridade { get; set; } = string.Empty;

        [BsonElement("observacao")]
        public string Observacao { get; set; } = string.Empty;
    }
}

