using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface ILojaNoturnaService
    {
        Task<LojaNoturnaModel> GerarLojaNoturna(int qtdArmas, int qtdArmaduras, int qtdArmasCiberneticas, int qtdCiberneticas, CancellationToken ct);
        Task<List<ArmasModel>> ObterTodasArmas(CancellationToken ct);
        Task<List<ArmaduraModel>> ObterTodasArmaduras(CancellationToken ct);
        Task<List<ArmasCiberneticasModel>> ObterTodasArmasCiberneticas(CancellationToken ct);
        Task<List<CiberneticasModel>> ObterTodasCiberneticas(CancellationToken ct);
        Task<LojaNoturnaModel> ObterLojaNoturna(CancellationToken ct);
        Task ComprarLojaNoturna(string id, decimal valor, int idPersonagem, CancellationToken ct);
    }
}
