using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ArmaPersonagemModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }

    [BsonElement("id_personagem")]
    public string IdPersonagem { get; set; } = string.Empty;

    [BsonElement("equipado")]
    public bool Equipado { get; set; }

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

    [BsonElement("dv26_50m")]
    public int Dv26_50m { get; set; }

    [BsonElement("dv51_100m")]
    public int Dv51_100m { get; set; }

    [BsonElement("dv101_200m")]
    public int Dv101_200m { get; set; }

    [BsonElement("detalhe")]
    public string Detalhe { get; set; } = string.Empty;

    [BsonElement("pericia")]
    public string Pericia { get; set; } = string.Empty;

    [BsonElement("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [BsonElement("preco")]
    public int Preco { get; set; }

    [BsonElement("grupo")]
    public string Grupo { get; set; } = string.Empty;

    [BsonElement("raridade")]
    public string Raridade { get; set; } = string.Empty;
}
