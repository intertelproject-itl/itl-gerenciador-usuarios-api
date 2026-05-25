using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class InventarioService(IMongoInventarioRepository<InventarioModel> repository) : IInventarioService
    {
        private readonly IMongoInventarioRepository<InventarioModel> _repository = repository;

        public async Task AdicionarItem(InventarioModel item, CancellationToken ct)
        {
            await _repository.InsertAsync(item, ct);
        }

        public async Task<List<InventarioModel>> ObterItens(string idPersonagem, CancellationToken ct)
        {
            var itens = await _repository.GetByIdAsync("idPersonagem", idPersonagem, ct);
            return itens != null ? new List<InventarioModel> { itens } : new List<InventarioModel>();
        }
    }
}
