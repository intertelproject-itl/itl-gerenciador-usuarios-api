namespace itl_gerenciador_usuarios_api.Domain.Interface.Services.v1
{
    public interface IJogatinaService
    {
        Task AtualizarDadosMaximoAsync(int idPersonagem, int hpMaximo = 0, int protecaoMaxima = 0, int sorteMaxima = 0, int humanidade = 0, CancellationToken ct = default);
        Task InfligirDanoAsync(int idPersonagem, int danoHp = 0, int danoProtecao = 0, int danoSorte = 0, int humanidade = 0, CancellationToken ct = default);
        Task InfligirFerimentosCriticosAsync(int idPersonagem, string ferimento = "", CancellationToken ct = default);
        Task CurarFerimentosCriticosAsync(int idPersonagem, string ferimento = "", bool curarTodos = false, CancellationToken ct = default);
        Task CurarHpAsync(int idPersonagem, int hpCurado = 0, bool hpTotal = false, CancellationToken ct = default);
        Task CurarProtecaoArmaduraMaximaAsync(int idPersonagem, int protecaoCurada = 0, bool protecaoTotal = false, CancellationToken ct = default);
        Task CurarSorteAsync(int idPersonagem, int sorteCurada = 0, bool sorteTotal = false, CancellationToken ct = default);
        Task CurarHumanidadeAsync(int idPersonagem, int humanidadeCurada = 0, bool humanidadeTotal = false, CancellationToken ct = default);
    }
}
