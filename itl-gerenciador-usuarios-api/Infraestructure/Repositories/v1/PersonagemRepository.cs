using Dapper;
using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace itl_gerenciador_usuarios_api.Infraestructure.Repositories.v1
{
    public class PersonagemRepository(AppDbContext db) : IPersonagemRepository
    {
        private readonly AppDbContext _db = db;

        public async Task<long> AddAsync(PersonagemRequestDTO personagemDto, CancellationToken ct)
        {
            const string sql = @"INSERT INTO personagens_base
                (id_usuario, id_sessao, nome, conceito, papel, idade, genero, origem, nivel_reputacao, humanidade_atual, humanidade_max, dinheiro, observacoes, data_criacao)
                VALUES
                (@IdUsuario, @IdSessao, @Nome, @Conceito, @Papel, @Idade, @Genero, @Origem, @NivelReputacao, @HumanidadeAtual, @HumanidadeMax, @Dinheiro, @Observacoes, @DataCriacao);
                SELECT LAST_INSERT_ID();";

            var parameters = new
            {
                IdUsuario = personagemDto.UsuarioId,
                IdSessao = personagemDto.SessionId,
                Nome = personagemDto.Nome ?? string.Empty,
                Conceito = personagemDto.Historia ?? string.Empty,
                Papel = personagemDto.Papel ?? string.Empty,
                Idade = personagemDto.Idade != null ? Convert.ToInt16(personagemDto.Idade) : 0,
                Genero = personagemDto.Genero ?? string.Empty,
                Origem = personagemDto.Origem ?? string.Empty,
                NivelReputacao = 0,
                HumanidadeAtual = 0,
                HumanidadeMax = 0,
                Dinheiro = personagemDto.Dinheiro ?? 0m,
                Observacoes = string.Empty,
                DataCriacao = DateTime.Now
            };

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            var idObj = await conn.ExecuteScalarAsync<object>(new CommandDefinition(sql, parameters, cancellationToken: ct));
            return Convert.ToInt64(idObj);
        }

        public async Task RegisterFullAsync(PersonagemRequestDTO personagemDto, CancellationToken ct)
        {
            var insertPersonSql = @"INSERT INTO personagens_base
                (id_usuario, id_sessao, nome, conceito, papel, idade, genero, origem, nivel_reputacao, humanidade_atual, humanidade_max, dinheiro, observacoes, data_criacao)
                VALUES
                (@IdUsuario, @IdSessao, @Nome, @Conceito, @Papel, @Idade, @Genero, @Origem, @NivelReputacao, @HumanidadeAtual, @HumanidadeMax, @Dinheiro, @Observacoes, @DataCriacao);
                SELECT LAST_INSERT_ID();";

            var personParams = new
            {
                IdUsuario = personagemDto.UsuarioId,
                IdSessao = personagemDto.SessionId,
                Nome = personagemDto.Nome ?? string.Empty,
                Conceito = personagemDto.Historia ?? string.Empty,
                Papel = personagemDto.Papel ?? string.Empty,
                Idade = personagemDto.Idade != null ? Convert.ToInt16(personagemDto.Idade) : 0,
                Genero = personagemDto.Genero ?? string.Empty,
                Origem = personagemDto.Origem ?? string.Empty,
                NivelReputacao = 0,
                HumanidadeAtual = 0,
                HumanidadeMax = 0,
                Dinheiro = personagemDto.Dinheiro ?? 0m,
                Observacoes = string.Empty,
                DataCriacao = DateTime.Now
            };

            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            using var transaction = conn.BeginTransaction();
            try
            {
                var idObj = await conn.ExecuteScalarAsync<object>(new CommandDefinition(insertPersonSql, personParams, transaction: transaction, cancellationToken: ct));
                long idPersonagem = Convert.ToInt64(idObj);

                var insertAtributosSql = @"INSERT INTO personagem_atributos
                    (id_personagem, inteligencia, reflexos, destreza, tecnica, frieza, vontade, sorte, movimento, corpo, empatia)
                    VALUES
                    (@IdPersonagem, @Inteligencia, @Reflexos, @Destreza, @Tecnica, @Frieza, @Vontade, @Sorte, @Movimento, @Corpo, @Empatia);";

                var attrParams = new
                {
                    IdPersonagem = idPersonagem,
                    Inteligencia = (short)1,
                    Reflexos = (short)1,
                    Destreza = (short)1,
                    Tecnica = (short)1,
                    Frieza = (short)1,
                    Vontade = (short)1,
                    Sorte = (short)1,
                    Movimento = (short)1,
                    Corpo = (short)1,
                    Empatia = (short)1
                };

                await conn.ExecuteAsync(new CommandDefinition(insertAtributosSql, attrParams, transaction: transaction, cancellationToken: ct));

                var insertPericiasSql = @"INSERT INTO personagem_pericias
                    (id_personagem, atletismo, briga, concentracao, conversa, educacao, evasao, intimidacao, percepcao, persuasao, pilotagem, primeiros_socorros, furtividade, sobrevivencia, negociacao, criminologia, deducao, resistir_drogas_tortura, tecnologia_basica, seguranca_eletronica, hackear, mecanica_terrestre, medicina, ciencia, armas_de_fogo, armas_pesadas, luta_corpo_a_corpo)
                    VALUES
                    (@IdPersonagem, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);";

                await conn.ExecuteAsync(new CommandDefinition(insertPericiasSql, new { IdPersonagem = idPersonagem }, transaction: transaction, cancellationToken: ct));

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static PersonagemModel PreparandoDados(PersonagemRequestDTO personagemDto)
        {
            return new PersonagemModel
            {
                Conceito = personagemDto.Historia ?? string.Empty,
                DataCriacao = DateTime.Now,
                Dinheiro = personagemDto.Dinheiro ?? 0,
                Genero = personagemDto.Genero ?? string.Empty,
                HumanidadeAtual = 0,
                HumanidadeMax = 0,
                Idade = personagemDto.Idade != null ? Convert.ToInt16(personagemDto.Idade) : 0,
                IdSessao = personagemDto.SessionId,
                IdUsuario = personagemDto.UsuarioId,
                NivelReputacao = 0,
                Observacoes = string.Empty,
                Origem = personagemDto.Origem ?? string.Empty,
                Papel = personagemDto.Papel ?? string.Empty,
                Nome = personagemDto.Nome ?? string.Empty
            };
        }
    }
}
