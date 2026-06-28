using System.Text.Json.Serialization;

namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class PersonagemRequestDTO
    {
        //[JsonPropertyName("dinheiro")]
        public decimal? Dinheiro { get; set; }

        //[JsonPropertyName("genero")]
        public string? Genero { get; set; }

        //[JsonPropertyName("historia")]
        public string? Historia { get; set; }

        //[JsonPropertyName("humanidade")]
        public string? Humanidade { get; set; }

        //[JsonPropertyName("idade")]
        public string? Idade { get; set; }

        //[JsonPropertyName("nome")]
        public string? Nome { get; set; }

        //[JsonPropertyName("origem")]
        public string? Origem { get; set; }

        //[JsonPropertyName("papel")]
        public string? Papel { get; set; }

        //[JsonPropertyName("sessionID")]
        public int SessionId { get; set; }

        //[JsonPropertyName("usuarioId")]
        public int UsuarioId { get; set; }
    }
}
