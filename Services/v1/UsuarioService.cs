using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Services.v1.Encrypt;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class UsuarioService(ILogger<UsuarioService> logger, IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly ILogger<UsuarioService> _logger = logger;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public Task<UsuarioModel?> GetByIdAsync(int id, CancellationToken ct) =>
            _usuarioRepository.GetByIdAsync(id, ct);
        public Task<List<UsuarioModel>> ListAsync(CancellationToken ct) =>
            _usuarioRepository.ListAsync(ct);

        public async Task AddAsync(UsuarioDTO usuario, CancellationToken ct)
        {
            string hashedPassword = PasswordHasher.Hash(usuario.Password);
            await _usuarioRepository.AddAsync(new UsuarioModel
            {
                Email = usuario.Email,
                SenhaHash = hashedPassword,
                Ativo = 1,
                DataCriacao = DateTime.UtcNow,
                Nickname = usuario.Nickname
            }, ct);
        }

        public async Task<UsuarioModel?> AutenticarAsync(string email, string password, CancellationToken ct)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email, ct);
            if (usuario == null)
                return null;
            var senhaValida = PasswordHasher.Verify(password, usuario.SenhaHash);
            if (!senhaValida)
                return null;
            return usuario;
        }
    }
}
