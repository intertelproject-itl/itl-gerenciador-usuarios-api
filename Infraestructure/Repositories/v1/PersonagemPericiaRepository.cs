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

        #region Buscar Pericias por ID do Personagem

        public async Task<PericiasArmasModel> GetPericiasArmasByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_armas WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasArmasModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasSociaisModel> GetPericiasSociaisByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_sociais WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasSociaisModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasTecnicasModel> GetPericiasTecnicasByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_tecnicas WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasTecnicasModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }
        public async Task<PericiasConducaoModel> GetPericiasConducaoByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_conducao WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasConducaoModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasAtencaoModel> GetPericiasAtencaoByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_atencao WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasAtencaoModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasEducacaoModel> GetPericiasEducacaoByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_educacao WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasEducacaoModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasCorporaisModel> GetPericiasCorporaisByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_corporais WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasCorporaisModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasLutaModel> GetPericiasLutaByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_luta WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasLutaModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        public async Task<PericiasPerformanceModel> GetPericiasPerformanceByIdPersonagemAsync(long idPersonagem, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM pericias_performance WHERE id_personagem = @IdPersonagem;";
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            return await conn.QueryFirstOrDefaultAsync<PericiasPerformanceModel>(new CommandDefinition(sql, new { IdPersonagem = idPersonagem }, cancellationToken: ct));
        }

        #endregion Buscar Pericias por ID do Personagem

        #region Atualizar Pericias por ID do Personagem

        public async Task UpdatePericiasArmasAsync(PericiasArmasModel periciasArmas, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_armas
                SET 
                    arqueirismo_base = @ArqueirismoBase,
                    arqueirismo_nivel = @ArqueirismoNivel,
                    automatica_base = @AutomaticaBase,
                    automatica_nivel = @AutomaticaNivel,
                    armas_curtas_base = @ArmasCurtasBase,
                    armas_curtas_nivel = @ArmasCurtasNivel,
                    armas_pesadas_base = @ArmasPesadasBase,
                    armas_pesadas_nivel = @ArmasPesadasNivel,
                    fuzil_base = @FuzilBase,
                    fuzil_nivel = @FuzilNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasArmas, cancellationToken: ct));
        }

        public async Task UpdatePericiasCorporaisAsync(PericiasCorporaisModel periciasCorporais, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_corporais
                SET 
                    atletismo_base = @AtletismoBase,
                    atletismo_nivel = @AtletismoNivel,
                    contorcionismo_base = @ContorcionismoBase,
                    contorcionismo_nivel = @ContorcionismoNivel,
                    dancar_base = @DancarBase,
                    dancar_nivel = @DancarNivel,
                    resistencia_base = @ResistenciaBase,
                    resistencia_nivel = @ResistenciaNivel,
                    resistencia_tortura_drogas_base = @ResistenciaTorturaDrogasBase,
                    resistencia_tortura_drogas_nivel = @ResistenciaTorturaDrogasNivel,
                    furtividade_base = @FurtividadeBase,
                    furtividade_nivel = @FurtividadeNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasCorporais, cancellationToken: ct));
        }

        public async Task UpdatePericiasConducaoAsync(PericiasConducaoModel periciasConducao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_conducao
                SET 
                    dirigir_veiculo_terrestre_base = @DirigirVeiculoTerrestreBase,
                    dirigir_veiculo_terrestre_nivel = @DirigirVeiculoTerrestreNivel,
                    pilotar_veiculo_aereo_base = @PilotarVeiculoAereoBase,
                    pilotar_veiculo_aereo_nivel = @PilotarVeiculoAereoNivel,
                    pilotar_veiculo_maritimo_base = @PilotarVeiculoMaritimoBase,
                    pilotar_veiculo_maritimo_nivel = @PilotarVeiculoMaritimoNivel,
                    motocicleta_base = @MotocicletaBase,
                    motocicleta_nivel = @MotocicletaNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasConducao, cancellationToken: ct));
        }

        public async Task UpdatePericiasLutaAsync(PericiasLutaModel periciasLuta, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_luta
                SET 
                    briga_base = @BrigaBase,
                    briga_nivel = @BrigaNivel,
                    evasao_base = @EvasaoBase,
                    evasao_nivel = @EvasaoNivel,
                    artes_marciais_base = @ArtesMarciaisBase,
                    artes_marciais_nivel = @ArtesMarciaisNivel,
                    armas_brancas_base = @ArmasBrancasBase,
                    armas_brancas_nivel = @ArmasBrancasNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasLuta, cancellationToken: ct));
        }

        public async Task UpdatePericiasAtencaoAsync(PericiasAtencaoModel periciasAtencao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_atencao
                SET 
                    observacao_base = @ObservacaoBase,
                    observacao_nivel = @ObservacaoNivel,
                    percepcao_base = @PercepcaoBase,
                    percepcao_nivel = @PercepcaoNivel,
                    raciocinio_base = @RaciocinioBase,
                    raciocinio_nivel = @RaciocinioNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasAtencao, cancellationToken: ct));
        }

        public async Task UpdatePericiasEducacaoAsync(PericiasEducacaoModel periciasEducacao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_educacao
                SET 
                    cultura_base = @CulturaBase,
                    cultura_nivel = @CulturaNivel,
                    historia_base = @HistoriaBase,
                    historia_nivel = @HistoriaNivel,
                    linguistica_base = @LinguisticaBase,
                    linguistica_nivel = @LinguisticaNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasEducacao, cancellationToken: ct));
        }

        public async Task UpdatePericiasTecnicasAsync(PericiasTecnicasModel periciasTecnicas, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_tecnicas
                SET 
                    informatica_base = @InformaticaBase,
                    informatica_nivel = @InformaticaNivel,
                    medicina_base = @MedicinaBase,
                    medicina_nivel = @MedicinaNivel,
                    engenharia_base = @EngenhariaBase,
                    engenharia_nivel = @EngenhariaNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasTecnicas, cancellationToken: ct));
        }

        public async Task UpdatePericiasSociaisAsync(PericiasSociaisModel periciasSociais, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);
            const string sql = @"
                UPDATE pericias_sociais
                SET 
                    persuasao_base = @PersuasaoBase,
                    persuasao_nivel = @PersuasaoNivel,
                    intimidacao_base = @IntimidacaoBase,
                    intimidacao_nivel = @IntimidacaoNivel,
                    negociacao_base = @NegociacaoBase,
                    negociacao_nivel = @NegociacaoNivel,
                    data_mudanca = NOW()
                WHERE id_personagem = @IdPersonagem;
            ";
            await conn.ExecuteAsync(new CommandDefinition(sql, periciasSociais, cancellationToken: ct));
        }
        
        #endregion Atualizar Pericias por ID do Personagem

        #region Inserir Pericias por ID do Personagem

        public async Task InsertPericiasArmasAsync(PericiasArmasModel periciasArmas, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_armas (
            id_sessao,
            id_personagem,
            arqueirismo_base,
            arqueirismo_nivel,
            automatica_base,
            automatica_nivel,
            armas_curtas_base,
            armas_curtas_nivel,
            armas_pesadas_base,
            armas_pesadas_nivel,
            fuzil_base,
            fuzil_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @ArqueirismoBase,
            @ArqueirismoNivel,
            @AutomaticaBase,
            @AutomaticaNivel,
            @ArmasCurtasBase,
            @ArmasCurtasNivel,
            @ArmasPesadasBase,
            @ArmasPesadasNivel,
            @FuzilBase,
            @FuzilNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasArmas, cancellationToken: ct));
        }

        public async Task InsertPericiasAtencaoAsync(PericiasAtencaoModel periciasAtencao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_atencao (
            id_sessao,
            id_personagem,
            concentracao_base,
            concentracao_nivel,
            ocultar_revelar_objeto_base,
            ocultar_revelar_objeto_nivel,
            leitura_labial_base,
            leitura_labial_nivel,
            percepcao_base,
            percepcao_nivel,
            rastrear_base,
            rastrear_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @ConcentracaoBase,
            @ConcentracaoNivel,
            @OcultarRevelarObjetoBase,
            @OcultarRevelarObjetoNivel,
            @LeituraLabialBase,
            @LeituraLabialNivel,
            @PercepcaoBase,
            @PercepcaoNivel,
            @RastrearBase,
            @RastrearNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasAtencao, cancellationToken: ct));
        }

        public async Task InsertPericiasConducaoAsync(PericiasConducaoModel periciasConducao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_conducao (
            id_sessao,
            id_personagem,
            dirigir_veiculo_terrestre_base,
            dirigir_veiculo_terrestre_nivel,
            pilotar_veiculo_aereo_base,
            pilotar_veiculo_aereo_nivel,
            pilotar_veiculo_maritimo_base,
            pilotar_veiculo_maritimo_nivel,
            motocicleta_base,
            motocicleta_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @DirigirVeiculoTerrestreBase,
            @DirigirVeiculoTerrestreNivel,
            @PilotarVeiculoAereoBase,
            @PilotarVeiculoAereoNivel,
            @PilotarVeiculoMaritimoBase,
            @PilotarVeiculoMaritimoNivel,
            @MotocicletaBase,
            @MotocicletaNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasConducao, cancellationToken: ct));
        }

        public async Task InsertPericiasCorporaisAsync(PericiasCorporaisModel periciasCorporais, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_corporais (
            id_sessao,
            id_personagem,
            atletismo_base,
            atletismo_nivel,
            contorcionismo_base,
            contorcionismo_nivel,
            dancar_base,
            dancar_nivel,
            resistencia_base,
            resistencia_nivel,
            resistencia_tortura_drogas_base,
            resistencia_tortura_drogas_nivel,
            furtividade_base,
            furtividade_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @AtletismoBase,
            @AtletismoNivel,
            @ContorcionismoBase,
            @ContorcionismoNivel,
            @DancarBase,
            @DancarNivel,
            @ResistenciaBase,
            @ResistenciaNivel,
            @ResistenciaTorturaDrogasBase,
            @ResistenciaTorturaDrogasNivel,
            @FurtividadeBase,
            @FurtividadeNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasCorporais, cancellationToken: ct));
        }

        public async Task InsertPericiasEducacaoAsync(PericiasEducacaoModel periciasEducacao, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_educacao (
            id_sessao,
            id_personagem,
            idioma_base,
            idioma_nivel,
            especialista_local_base,
            especialista_local_nivel,
            contabilidade_base,
            contabilidade_nivel,
            lidar_com_animais_base,
            lidar_com_animais_nivel,
            burocracia_base,
            burocracia_nivel,
            negocios_base,
            negocios_nivel,
            composicao_base,
            composicao_nivel,
            criminologia_base,
            criminologia_nivel,
            criptografia_base,
            criptografia_nivel,
            deducao_base,
            deducao_nivel,
            educacao_base,
            educacao_nivel,
            apostar_base,
            apostar_nivel,
            pesquisa_biblioteca_base,
            pesquisa_biblioteca_nivel,
            estrategia_base,
            estrategia_nivel,
            sobrevivencia_base,
            sobrevivencia_nivel,
            ciencia_base,
            ciencia_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @IdiomaBase,
            @IdiomaNivel,
            @EspecialistaLocalBase,
            @EspecialistaLocalNivel,
            @ContabilidadeBase,
            @ContabilidadeNivel,
            @LidarComAnimaisBase,
            @LidarComAnimaisNivel,
            @BurocraciaBase,
            @BurocraciaNivel,
            @NegociosBase,
            @NegociosNivel,
            @ComposicaoBase,
            @ComposicaoNivel,
            @CriminologiaBase,
            @CriminologiaNivel,
            @CriptografiaBase,
            @CriptografiaNivel,
            @DeducaoBase,
            @DeducaoNivel,
            @EducacaoBase,
            @EducacaoNivel,
            @ApostarBase,
            @ApostarNivel,
            @PesquisaBibliotecaBase,
            @PesquisaBibliotecaNivel,
            @EstrategiaBase,
            @EstrategiaNivel,
            @SobrevivenciaBase,
            @SobrevivenciaNivel,
            @CienciaBase,
            @CienciaNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasEducacao, cancellationToken: ct));
        }

        public async Task InsertPericiasLutaAsync(PericiasLutaModel periciasLuta, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_luta (
            id_sessao,
            id_personagem,
            briga_base,
            briga_nivel,
            evasao_base,
            evasao_nivel,
            artes_marciais_base,
            artes_marciais_nivel,
            armas_brancas_base,
            armas_brancas_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @BrigaBase,
            @BrigaNivel,
            @EvasaoBase,
            @EvasaoNivel,
            @ArtesMarciaisBase,
            @ArtesMarciaisNivel,
            @ArmasBrancasBase,
            @ArmasBrancasNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasLuta, cancellationToken: ct));
        }

        public async Task InsertPericiasPerformanceAsync(PericiasPerformanceModel periciasPerformance, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_performance (
            id_sessao,
            id_personagem,
            atuacao_base,
            atuacao_nivel,
            tocar_instrumento_base,
            tocar_instrumento_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @AtuacaoBase,
            @AtuacaoNivel,
            @TocarInstrumentoBase,
            @TocarInstrumentoNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasPerformance, cancellationToken: ct));
        }

        public async Task InsertPericiasSociaisAsync(PericiasSociaisModel periciasSociais, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_sociais (
            id_sessao,
            id_personagem,
            suborno_base,
            suborno_nivel,
            oratoria_base,
            oratoria_nivel,
            percepcao_humana_base,
            percepcao_humana_nivel,
            interrogatorio_base,
            interrogatorio_nivel,
            persuasao_base,
            persuasao_nivel,
            cuidados_pessoais_base,
            cuidados_pessoais_nivel,
            malandragem_base,
            malandragem_nivel,
            negociacao_base,
            negociacao_nivel,
            roupa_estilo_base,
            roupa_estilo_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @SubornoBase,
            @SubornoNivel,
            @OratoriaBase,
            @OratoriaNivel,
            @PercepcaoHumanaBase,
            @PercepcaoHumanaNivel,
            @InterrogatorioBase,
            @InterrogatorioNivel,
            @PersuasaoBase,
            @PersuasaoNivel,
            @CuidadosPessoaisBase,
            @CuidadosPessoaisNivel,
            @MalandragemBase,
            @MalandragemNivel,
            @NegociacaoBase,
            @NegociacaoNivel,
            @RoupaEstiloBase,
            @RoupaEstiloNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasSociais, cancellationToken: ct));
        }

        public async Task InsertPericiasTecnicasAsync(PericiasTecnicasModel periciasTecnicas, CancellationToken ct)
        {
            var conn = _db.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) await conn.OpenAsync(ct);

            const string sql = @"
        INSERT INTO pericias_tecnicas (
            id_sessao,
            id_personagem,
            tecnologia_veiculos_aereos_base,
            tecnologia_veiculos_aereos_nivel,
            tecnologia_basica_base,
            tecnologia_basica_nivel,
            cibertecnologia_base,
            cibertecnologia_nivel,
            demolicoes_base,
            demolicoes_nivel,
            eletronica_tec_seguranca_base,
            eletronica_tec_seguranca_nivel,
            primeiros_socorros_base,
            primeiros_socorros_nivel,
            falsificacao_base,
            falsificacao_nivel,
            tecnologia_veiculo_terrestre_base,
            tecnologia_veiculo_terrestre_nivel,
            pintar_desenhar_esculpir_base,
            pintar_desenhar_esculpir_nivel,
            fotografia_filmagem_base,
            fotografia_filmagem_nivel,
            arrombamento_base,
            arrombamento_nivel,
            furto_base,
            furto_nivel,
            tecnologia_veiculo_maritimo_base,
            tecnologia_veiculo_maritimo_nivel,
            tecnologia_armas_armeiro_base,
            tecnologia_armas_armeiro_nivel,
            data_criacao
        ) VALUES (
            @IdSessao,
            @IdPersonagem,
            @TecnologiaVeiculosAereosBase,
            @TecnologiaVeiculosAereosNivel,
            @TecnologiaBasicaBase,
            @TecnologiaBasicaNivel,
            @CibertecnologiaBase,
            @CibertecnologiaNivel,
            @DemolicoesBase,
            @DemolicoesNivel,
            @EletronicaTecSegurancaBase,
            @EletronicaTecSegurancaNivel,
            @PrimeirosSocorrosBase,
            @PrimeirosSocorrosNivel,
            @FalsificacaoBase,
            @FalsificacaoNivel,
            @TecnologiaVeiculoTerrestreBase,
            @TecnologiaVeiculoTerrestreNivel,
            @PintarDesenharEsculpirBase,
            @PintarDesenharEsculpirNivel,
            @FotografiaFilmagemBase,
            @FotografiaFilmagemNivel,
            @ArrombamentoBase,
            @ArrombamentoNivel,
            @FurtoBase,
            @FurtoNivel,
            @TecnologiaVeiculoMaritimoBase,
            @TecnologiaVeiculoMaritimoNivel,
            @TecnologiaArmasArmeiroBase,
            @TecnologiaArmasArmeiroNivel,
            NOW()
        );
    ";

            await conn.ExecuteAsync(new CommandDefinition(sql, periciasTecnicas, cancellationToken: ct));
        }



        #endregion Inserir Pericias por ID do Personagem
    }
}
