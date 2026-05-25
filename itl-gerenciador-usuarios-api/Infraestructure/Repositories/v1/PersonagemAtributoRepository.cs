using Dapper;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1
{
    public class PersonagemAtributoRepository(AppDbContext db) : IPersonagemAtributoRepository
    {
        private readonly AppDbContext _db = db;

        public async Task AddAsync(PersonagemAtributosModel personagemAtributo, CancellationToken ct)
        {
            const string sql = @"INSERT INTO personagem_atributos
                (id_personagem, inteligencia, reflexos, destreza, tecnica, frieza, vontade, sorte, movimento, corpo, empatia, editavel)
                VALUES
                (@IdPersonagem, @Inteligencia, @Reflexos, @Destreza, @Tecnica, @Frieza, @Vontade, @Sorte, @Movimento, @Corpo, @Empatia, @Editavel);";

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, personagemAtributo, cancellationToken: ct));
        }

        public async Task UpdateAsync(PersonagemAtributosModel personagemAtributo, CancellationToken ct)
        {
            const string sql = @"UPDATE personagem_atributos SET
                inteligencia = @Inteligencia,
                reflexos = @Reflexos,
                destreza = @Destreza,
                tecnica = @Tecnica,
                frieza = @Frieza,
                vontade = @Vontade,
                sorte = @Sorte,
                movimento = @Movimento,
                corpo = @Corpo,
                empatia = @Empatia,
                editavel = 0
                WHERE id_personagem = @IdPersonagem;";

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, personagemAtributo, cancellationToken: ct));
        }
    }
}
