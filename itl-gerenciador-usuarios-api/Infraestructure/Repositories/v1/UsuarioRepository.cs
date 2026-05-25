using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1
{
    public class UsuarioRepository(AppDbContext db) : IUsuarioRepository
    {
        private readonly AppDbContext _db = db;

        public Task<UsuarioModel?> GetByEmailAsync(string email, CancellationToken ct) =>
            _db.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, ct);

        public Task<UsuarioModel?> GetByIdAsync(int id, CancellationToken ct) =>
            _db.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.IdUsuario == id, ct);

        public Task<List<UsuarioModel>> ListAsync(CancellationToken ct) =>
            _db.Usuarios.AsNoTracking().OrderBy(x => x.IdUsuario).ToListAsync(ct);

        public async Task AddAsync(UsuarioModel cliente, CancellationToken ct)
        {
            await _db.Usuarios.AddAsync(cliente, ct);
            _db.SaveChanges();
        }
    }
}
