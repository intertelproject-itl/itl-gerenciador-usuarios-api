using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IInventarioService
    {
        Task AdicionarItem(InvetarioRequestDto item, CancellationToken ct);
        Task<List<InventarioResponseDTO>> ObterItens(string idPersonagem, CancellationToken ct);
    }
}
