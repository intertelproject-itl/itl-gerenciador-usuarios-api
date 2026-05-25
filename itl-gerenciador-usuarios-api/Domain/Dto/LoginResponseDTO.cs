using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Dto
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; } = "";
        public DateTime Expiration { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
