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

        #region Metodos Publicos
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

        public async Task AtualizarBriefingAsync(int idPersonagem, string briefing, CancellationToken ct)
        {
            const string sql = "UPDATE personagens_base SET conceito = @Briefing WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, new { Briefing = briefing, IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task AtualizarDadosPersonagemAsync(int idPersonagem, int hpMaximo, int protecaoMaxima, int humanidade, int sorteMaxima, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (hpMaximo > 0)
            {
                sql = "UPDATE personagens_base SET hp_maximo = @HpMaximo WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { HpMaximo = hpMaximo, IdPersonagem = idPersonagem }, cancellationToken: ct));                
            }
            if (protecaoMaxima > 0)
            {
                sql = "UPDATE personagens_base SET protecao_armadura_maxima = @ProtecaoMaxima WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { ProtecaoMaxima = protecaoMaxima, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            if (humanidade > 0)
            {
                sql = "UPDATE personagens_base SET humanidade_max = @HumanidadeMax WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { HumanidadeMax = humanidade, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            if (sorteMaxima > 0)
            {
                sql = "UPDATE personagens_base SET sorte_maxima = @SorteMaxima WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { SorteMaxima = sorteMaxima, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task InfligirDanoAsync(int idPersonagem, int danoHp, int danoProtecao, int danoSorte, int humanidade, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (danoHp > 0)
            {
                sql = "UPDATE personagens_base SET hp_atual = GREATEST(hp_atual - @DanoHp, 0) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { DanoHp = danoHp, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            if (danoProtecao > 0)
            {
                sql = "UPDATE personagens_base SET protecao_armadura_atual = GREATEST(protecao_armadura_atual - @DanoProtecao, 0) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { DanoProtecao = danoProtecao, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            if (danoSorte > 0)
            {
                sql = "UPDATE personagens_base SET sorte_atual = GREATEST(sorte_atual - @DanoSorte, 0) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { DanoSorte = danoSorte, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            if (humanidade > 0)
            {
                sql = "UPDATE personagens_base SET humanidade_atual = GREATEST(humanidade_atual - @Humanidade, 0) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { Humanidade = humanidade, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task InfligirFerimentoCriticoAsync(int idPersonagem, string ferimento, CancellationToken ct)
        {
            var sql = "UPDATE personagens_base SET ferimentos_criticos = CONCAT(IFNULL(ferimentos_criticos, ''), @Ferimento) WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, new { Ferimento = ferimento, IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task CurarHpMaximoAsync(int idPersonagem, int hpCurado, bool hpTotal, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (hpTotal)
            {
                sql = "UPDATE personagens_base SET hp_atual = hp_maximo WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            else if (hpCurado > 0)
            {
                sql = "UPDATE personagens_base SET hp_atual = LEAST(hp_atual + @HpCurado, hp_maximo) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { HpCurado = hpCurado, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task CurarProtecaoArmaduraMaximaAsync(int idPersonagem, int protecaoCurada, bool protecaoTotal, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (protecaoTotal)
            {
                sql = "UPDATE personagens_base SET protecao_armadura_atual = protecao_armadura_maxima WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            else if (protecaoCurada > 0)
            {
                sql = "UPDATE personagens_base SET protecao_armadura_atual = LEAST(protecao_armadura_atual + @ProtecaoCurada, protecao_armadura_maxima) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { ProtecaoCurada = protecaoCurada, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task CurarSorteMaximaAsync(int idPersonagem, int sorteCurada, bool sorteTotal, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (sorteTotal)
            {
                sql = "UPDATE personagens_base SET sorte_atual = sorte_maxima WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            else if (sorteCurada > 0)
            {
                sql = "UPDATE personagens_base SET sorte_atual = LEAST(sorte_atual + @SorteCurada, sorte_maxima) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { SorteCurada = sorteCurada, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task CurarHumanidadeMaximaAsync(int idPersonagem, int humanidadeCurada, bool humanidadeTotal, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (humanidadeTotal)
            {
                sql = "UPDATE personagens_base SET humanidade_atual = humanidade_max WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            else if (humanidadeCurada > 0)
            {
                sql = "UPDATE personagens_base SET humanidade_atual = LEAST(humanidade_atual + @HumanidadeCurada, humanidade_max) WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { HumanidadeCurada = humanidadeCurada, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }

        public async Task CurarFerimentoAsync(int idPersonagem, string ferimento, bool curarTodos, CancellationToken ct)
        {
            var sql = string.Empty;
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            if (curarTodos)
            {
                sql = "UPDATE personagens_base SET ferimentos_criticos = NULL WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
            else
            {
                sql = "UPDATE personagens_base SET ferimentos_criticos = REPLACE(ferimentos_criticos, @Ferimento, '') WHERE id_personagem = @IdPersonagem;";
                await conn.ExecuteAsync(new CommandDefinition(sql, new { Ferimento = ferimento, IdPersonagem = idPersonagem }, cancellationToken: ct));
            }
        }
        
        public async Task ComprarItem(int idPersonagem, decimal valor, CancellationToken ct)
        {
            var sql = "UPDATE personagens_base SET dinheiro = dinheiro - @Valor WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            await conn.ExecuteAsync(new CommandDefinition(sql, new { Valor = valor, IdPersonagem = idPersonagem }, cancellationToken: ct));
        }
        #endregion Metodos Publicos


        #region Metodos Privados
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
        #endregion Metodos Privados
    }
}
