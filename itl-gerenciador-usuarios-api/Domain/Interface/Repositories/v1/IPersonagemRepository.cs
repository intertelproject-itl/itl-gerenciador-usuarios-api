using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IPersonagemRepository
    {
        Task<long> AddAsync(PersonagemRequestDTO personagemDto, CancellationToken ct);       
    }
}
