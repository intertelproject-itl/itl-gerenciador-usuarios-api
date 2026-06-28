using Dapper;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1
{
    public class PersonagemPericiaRepository(AppDbContext db) : IPersonagemPericiaRepository
    {
        private readonly AppDbContext _db = db;

        public async Task AddAsync(PersonagemPericiasModel personagemPericia, CancellationToken ct)
        {
            const string sql = @"INSERT INTO personagem_pericias
                (id_personagem, atletismo, briga, concentracao, conversa, educacao, evasao, intimidacao, percepcao, persuasao, pilotagem, primeiros_socorros, furtividade, sobrevivencia, negociacao, criminologia, deducao, resistir_drogas_tortura, tecnologia_basica, seguranca_eletronica, hackear, mecanica_terrestre, medicina, ciencia, armas_de_fogo, armas_pesadas, luta_corpo_a_corpo, editavel)
                VALUES
                (@IdPersonagem, @Atletismo, @Briga, @Concentracao, @Conversa, @Educacao, @Evasao, @Intimidacao, @Percepcao, @Persuasao, @Pilotagem, @PrimeirosSocorros, @Furtividade, @Sobrevivencia, @Negociacao, @Criminologia, @Deducao, @ResistirDrogasTortura, @TecnologiaBasica, @SegurancaEletronica, @Hackear, @MecanicaTerrestre, @Medicina, @Ciencia, @ArmasDeFogo, @ArmasPesadas, @LutaCorpoACorpo, @Editavel);";

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, personagemPericia, cancellationToken: ct));
        }

        public async Task UpdateAsync(PersonagemPericiasModel personagemPericia, CancellationToken ct)
        {
            const string sql = @"UPDATE personagem_pericias SET
                atletismo = @Atletismo,
                briga = @Briga,
                concentracao = @Concentracao,
                conversa = @Conversa,
                educacao = @Educacao,
                evasao = @Evasao,
                intimidacao = @Intimidacao,
                percepcao = @Percepcao,
                persuasao = @Persuasao,
                pilotagem = @Pilotagem,
                primeiros_socorros = @PrimeirosSocorros,
                furtividade = @Furtividade,
                sobrevivencia = @Sobrevivencia,
                negociacao = @Negociacao,
                criminologia = @Criminologia,
                deducao = @Deducao,
                resistir_drogas_tortura = @ResistirDrogasTortura,
                tecnologia_basica = @TecnologiaBasica,
                seguranca_eletronica = @SegurancaEletronica,
                hackear = @Hackear,
                mecanica_terrestre = @MecanicaTerrestre,
                medicina = @Medicina,
                ciencia = @Ciencia,
                armas_de_fogo = @ArmasDeFogo,
                armas_pesadas = @ArmasPesadas,
                luta_corpo_a_corpo = @LutaCorpoACorpo,
                editavel = 0
                WHERE id_personagem = @IdPersonagem;";

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, personagemPericia, cancellationToken: ct));
        }
    }
}
