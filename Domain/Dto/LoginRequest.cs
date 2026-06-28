using System.Text.Json.Serialization;

namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class LoginRequestDTO
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("password")]
        public required string Password { get; set; }
    }
}
