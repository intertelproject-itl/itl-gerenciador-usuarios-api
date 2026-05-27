using itl_gerenciador_usuarios_api.Domain.Dto;

namespace itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1
{
    public interface IPersonagemRepository
    {
        Task<long> AddAsync(PersonagemRequestDTO personagemDto, CancellationToken ct);
        Task AtualizarDadosPersonagemAsync(int idPersonagem, int hpMaximo, int protecaoMaxima, int humanidade, int sorteMaxima, CancellationToken ct);
        Task InfligirDanoAsync(int idPersonagem, int danoHp, int danoProtecao, int danoSorte, int humanidade, CancellationToken ct);
        Task CurarHpMaximoAsync(int idPersonagem, int hpCurado, bool hpTotal, CancellationToken ct);
        Task CurarProtecaoArmaduraMaximaAsync(int idPersonagem, int protecaoCurada, bool protecaoTotal, CancellationToken ct);
        Task CurarSorteMaximaAsync(int idPersonagem, int sorteCurada, bool sorteTotal, CancellationToken ct);
        Task InfligirFerimentoCriticoAsync(int idPersonagem, string ferimento, CancellationToken ct);
        Task CurarFerimentoAsync(int idPersonagem, string ferimento, bool curarTodos, CancellationToken ct);
        Task CurarHumanidadeMaximaAsync(int idPersonagem, int humanidadeCurada, bool humanidadeTotal, CancellationToken ct);
    }
}
