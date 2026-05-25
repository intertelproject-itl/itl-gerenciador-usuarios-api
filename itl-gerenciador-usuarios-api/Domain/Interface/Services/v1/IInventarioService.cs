using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IInventarioService
    {
        Task AdicionarItem(InventarioModel item, CancellationToken ct);
        Task<List<InventarioModel>> ObterItens(string idPersonagem, CancellationToken ct);
    }
}
