using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IPersonagemService
    {
        Task RegistrarPersonagem(PersonagemRequestDTO personagemDto, CancellationToken ct);
        Task UpdateAtributos(PersonagemAtributosModel atributos, CancellationToken ct);
        Task UpdatePericias(PersonagemPericiasModel pericias, CancellationToken ct);
    }
}
