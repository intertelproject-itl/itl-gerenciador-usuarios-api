using Dapper;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Ports.Outbound;
using Microsoft.EntityFrameworkCore;

namespace itl_gerenciador_usuarios_api.Adapters.Outbound
{
    public class PersonagemOutboundAdapter(AppDbContext db) : IPersonagemOutboundPort
    {
        private readonly AppDbContext _db = db;

        public async Task<PersonagemModel> GetPersonagemBySessaoAndUsuarioAsync(long idSessao, long idUsuario)
        {
            const string sql = @"SELECT * FROM personagens_base WHERE id_sessao = @IdSessao AND id_usuario = @IdUsuario LIMIT 1";
            using var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync();
            var personagem = await conn.QuerySingleOrDefaultAsync<PersonagemModel>(sql, new { IdSessao = idSessao, IdUsuario = idUsuario });
            return personagem ?? throw new Exception("Nenhum personagem encontrado para a sessão/usuário informados");
        }

        public async Task<PersonagemPericiasModel> GetPersonagemPericiasBySessaoAndUsuarioAsync(long idSessao, long idUsuario)
        {
            const string sql = @"
                SELECT pp.*
                FROM personagem_pericias pp
                INNER JOIN personagens_base p ON pp.id_personagem = p.id_personagem
                WHERE p.id_sessao = @IdSessao AND p.id_usuario = @IdUsuario
                LIMIT 1";
            using var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync();
            var pericias = await conn.QuerySingleOrDefaultAsync<PersonagemPericiasModel>(sql, new { IdSessao = idSessao, IdUsuario = idUsuario });
            return pericias ?? throw new Exception("Nenhuma perícia encontrada para o personagem");
        }

        public async Task<PersonagemAtributosModel> GetPersonagemAtributosBySessaoAndUsuarioAsync(long idSessao, long idUsuario)
        {
            const string sql = @"
                SELECT pa.*
                FROM personagem_atributos pa
                INNER JOIN personagens_base p ON pa.id_personagem = p.id_personagem
                WHERE p.id_sessao = @IdSessao AND p.id_usuario = @IdUsuario
                LIMIT 1";
            using var conn = _db.Database.GetDbConnection();
            if (conn.State == System.Data.ConnectionState.Closed) await conn.OpenAsync();
            var atributos = await conn.QuerySingleOrDefaultAsync<PersonagemAtributosModel>(sql, new { IdSessao = idSessao, IdUsuario = idUsuario });
            return atributos ?? throw new Exception("Nenhum atributo encontrado para o personagem");
        }
    }
}
