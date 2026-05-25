using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Dapper;
// outbound ports not required here; repository implements domain interface

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1
{
    public class SessaoJogatinaRepository(AppDbContext db) : ISessaoJogatinaRepository
    {
        static SessaoJogatinaRepository()
        {
            // permite mapear colunas com underscore para propriedades PascalCase
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        private readonly AppDbContext _db = db;

        public async Task AddAsync(SessaoJogatinaModel sessao, CancellationToken ct)
        {
            // Mantém comportamento original via EF para inserção
            await _db.SessoesJogatina.AddAsync(sessao, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<List<SessaoJogatinaModel>> GetSessaoPublicaAsync(CancellationToken ct)
        {
            const string sql = @"SELECT * FROM sessao_jogatina WHERE publica = 1 AND ativo = 1";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync(ct);
            var result = await conn.QueryAsync<SessaoJogatinaModel>(new CommandDefinition(sql, cancellationToken: ct));
            return result.AsList();
        }

        public async Task<SessaoJogatinaModel> GetByIdAsync(long idSessao)
        {
            const string sql = @"SELECT * FROM sessao_jogatina WHERE id_sessao = @IdSessao LIMIT 1";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync();
            var sessao = await conn.QuerySingleOrDefaultAsync<SessaoJogatinaModel>(sql, new { IdSessao = idSessao });
            return sessao ?? throw new Exception("Nenhuma Sessão Encontrada");
        }

        public async Task<PersonagemModel> GetPersonagemBySessaoAndUsuarioAsync(long idSessao, long idUsuario, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM personagens_base WHERE id_sessao = @IdSessao AND id_usuario = @IdUsuario LIMIT 1";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync(ct);
            var personagem = await conn.QuerySingleOrDefaultAsync<PersonagemModel>(new CommandDefinition(sql, new { IdSessao = idSessao, IdUsuario = idUsuario }, cancellationToken: ct));
            return personagem ?? throw new Exception("Nenhum personagem encontrado para a sessão/usuário informados");
        }

        public async Task<PersonagemPericiasModel> GetPersonagemPericiasBySessaoAndUsuarioAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"
                SELECT pp.*
                FROM personagem_pericias pp
                INNER JOIN personagens_base p ON pp.id_personagem = p.id_personagem
                WHERE p.id_personagem = @IdPersonagem
                LIMIT 1";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync(ct);
            var pericias = await conn.QuerySingleOrDefaultAsync<PersonagemPericiasModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            return pericias ?? throw new Exception("Nenhuma perícia encontrada para o personagem");
        }

        public async Task<PersonagemAtributosModel> GetPersonagemAtributosBySessaoAndUsuarioAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"
                SELECT pa.*
                FROM personagem_atributos pa
                INNER JOIN personagens_base p ON pa.id_personagem = p.id_personagem
                WHERE p.id_personagem = @IdPersonagem
                LIMIT 1";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync(ct);
            var atributos = await conn.QuerySingleOrDefaultAsync<PersonagemAtributosModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            return atributos ?? throw new Exception("Nenhum atributo encontrado para o personagem");
        }
    }
}
