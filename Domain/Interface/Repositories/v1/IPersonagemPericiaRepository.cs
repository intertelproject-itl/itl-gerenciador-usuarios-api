using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IPersonagemPericiaRepository
    {
        Task AddAsync(PersonagemPericiasModel pericias, CancellationToken ct);
        Task UpdateAsync(PersonagemPericiasModel pericias, CancellationToken ct);
    }
}
