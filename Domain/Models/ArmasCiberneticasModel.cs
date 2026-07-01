namespace itl_gerenciador_usuarios_api.Domain.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class ArmasCiberneticasModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("dano")]
        public string Dano { get; set; } = string.Empty;

        [BsonElement("dv0_6m")]
        public int Dv0_6m { get; set; }

        [BsonElement("dv7_12m")]
        public int Dv7_12m { get; set; }

        [BsonElement("dv13_25m")]
        public int Dv13_25m { get; set; }

        [BsonElement("detalhe")]
        public string Detalhe { get; set; } = string.Empty;

        [BsonElement("pericia")]
        public string Pericia { get; set; } = string.Empty;

        [BsonElement("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [BsonElement("preco")]
        public int Preco { get; set; }

        [BsonElement("instalacao")]
        public string Instalacao { get; set; } = string.Empty;

        [BsonElement("custoHumanidade")]
        public string CustoHumanidade { get; set; } = string.Empty;

        [BsonElement("observacao")]
        public string Observacao { get; set; } = string.Empty;

        [BsonElement("raridade")]
        public string Raridade { get; set; } = string.Empty;
    }

}
