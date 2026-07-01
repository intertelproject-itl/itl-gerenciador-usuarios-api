using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IPersonagemPericiaRepository
    {
        #region Buscar Pericias por ID do Personagem

        Task<PericiasArmasModel> GetPericiasArmasByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasSociaisModel> GetPericiasSociaisByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasTecnicasModel> GetPericiasTecnicasByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasConducaoModel> GetPericiasConducaoByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasAtencaoModel> GetPericiasAtencaoByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasEducacaoModel> GetPericiasEducacaoByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasCorporaisModel> GetPericiasCorporaisByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasLutaModel> GetPericiasLutaByIdPersonagemAsync(
            long idPersonagem,
            CancellationToken ct);

        Task<PericiasPerformanceModel> GetPericiasPerformanceByIdPersonagemAsync(long idPersonagem, CancellationToken ct);

        #endregion Buscar Pericias por ID do Personagem

        #region Atualizar Pericias por ID do Personagem

        Task UpdatePericiasPerformanceAsync(PericiasPerformanceModel periciasPerformance, CancellationToken ct);

        Task UpdatePericiasArmasAsync(
            PericiasArmasModel periciasArmas,
            CancellationToken ct);

        Task UpdatePericiasCorporaisAsync(
            PericiasCorporaisModel periciasCorporais,
            CancellationToken ct);

        Task UpdatePericiasConducaoAsync(
            PericiasConducaoModel periciasConducao,
            CancellationToken ct);

        Task UpdatePericiasLutaAsync(
            PericiasLutaModel periciasLuta,
            CancellationToken ct);

        Task UpdatePericiasAtencaoAsync(
            PericiasAtencaoModel periciasAtencao,
            CancellationToken ct);

        Task UpdatePericiasEducacaoAsync(
            PericiasEducacaoModel periciasEducacao,
            CancellationToken ct);

        Task UpdatePericiasTecnicasAsync(
            PericiasTecnicasModel periciasTecnicas,
            CancellationToken ct);

        Task UpdatePericiasSociaisAsync(
            PericiasSociaisModel periciasSociais,
            CancellationToken ct);

        #endregion Atualizar Pericias por ID do Personagem

        #region Inserir Pericias por ID do Personagem

        Task InsertPericiasArmasAsync(
            PericiasArmasModel periciasArmas,
            CancellationToken ct);

        Task InsertPericiasAtencaoAsync(
            PericiasAtencaoModel periciasAtencao,
            CancellationToken ct);

        Task InsertPericiasConducaoAsync(
            PericiasConducaoModel periciasConducao,
            CancellationToken ct);

        Task InsertPericiasCorporaisAsync(
            PericiasCorporaisModel periciasCorporais,
            CancellationToken ct);

        Task InsertPericiasEducacaoAsync(
            PericiasEducacaoModel periciasEducacao,
            CancellationToken ct);

        Task InsertPericiasLutaAsync(
            PericiasLutaModel periciasLuta,
            CancellationToken ct);

        Task InsertPericiasPerformanceAsync(
            PericiasPerformanceModel periciasPerformance,
            CancellationToken ct);

        Task InsertPericiasSociaisAsync(
            PericiasSociaisModel periciasSociais,
            CancellationToken ct);

        Task InsertPericiasTecnicasAsync(
            PericiasTecnicasModel periciasTecnicas,
            CancellationToken ct);

        #endregion Inserir Pericias por ID do Personagem
    }
}
