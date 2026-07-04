using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IInventarioService
    {
        List<InventarioModel> BuscarInventarioPorPersonagem(int idPersonagem);
        Task InserirNovoItem<T>(T item, IFormFile imagem, CancellationToken ct);
        Task PassarItemAsync(string idItem, bool duplicavel, int idPersonagemOrigem, int idPersonagemDestino, CancellationToken ct);
    }
}
