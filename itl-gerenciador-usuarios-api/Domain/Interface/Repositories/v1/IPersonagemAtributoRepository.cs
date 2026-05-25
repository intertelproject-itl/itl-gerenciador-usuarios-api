using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IPersonagemAtributoRepository
    {
        Task AddAsync(PersonagemAtributosModel atributos, CancellationToken ct);
        Task UpdateAsync(PersonagemAtributosModel atributos, CancellationToken ct);
    }
}
