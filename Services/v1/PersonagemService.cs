using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using itl_gerenciador_usuarios_api.Infraestructure.Integration;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class PersonagemService(IPersonagemRepository personagemRepository, IWebHostEnvironment env,
        IPersonagemAtributoRepository personagemAtributoRepository, IPersonagemPericiaRepository personagemPericiaRepository, SignalRService signalRService) : ServiceBase(signalRService), IPersonagemService
    {
        private readonly IWebHostEnvironment _env = env;
        private readonly IPersonagemRepository _personagemRepository = personagemRepository;
        private readonly IPersonagemAtributoRepository _personagemAtributoRepository = personagemAtributoRepository;
        private readonly IPersonagemPericiaRepository _personagemPericiaRepository = personagemPericiaRepository;


        public async Task AtualizarValorPericias(PersonagemPericiaDTO personagemPericia)
        {
            await _personagemPericiaRepository.UpdatePericiasLutaAsync(personagemPericia.PericiasLuta, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasAtencaoAsync(personagemPericia.PericiasAtencao, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasConducaoAsync(personagemPericia.PericiasConducao, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasCorporaisAsync(personagemPericia.PericiasCorporais, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasEducacaoAsync(personagemPericia.PericiasEducacao, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasPerformanceAsync(personagemPericia.PericiasPerformance, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasSociaisAsync(personagemPericia.PericiasSociais, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasTecnicasAsync(personagemPericia.PericiasTecnicas, new CancellationToken());
            await _personagemPericiaRepository.UpdatePericiasArmasAsync(personagemPericia.PericiasArmas, new CancellationToken());

            await _signalRService.AtualizarPericia((int)personagemPericia.PericiasLuta.IdPersonagem, (int)personagemPericia.PericiasLuta.IdSessao);
        }

        public async Task RegistrarPersonagem(PersonagemRequestDTO personagem, CancellationToken ct)
        {
            var idPersonagem = await _personagemRepository.AddAsync(personagem, ct);
            var atributos = new PersonagemAtributosModel
            {
                IdPersonagem = idPersonagem,
                Inteligencia = 1,
                Reflexos = 1,
                Destreza = 1,
                Tecnica = 1,
                Frieza = 1,
                Vontade = 1,
                Sorte = 1,
                Movimento = 1,
                Corpo = 1,
                Empatia = 1,
                Editavel = 1
            };

            // cria pericias zeradas
            await _personagemPericiaRepository.InsertPericiasArmasAsync(new PericiasArmasModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasAtencaoAsync(new PericiasAtencaoModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasConducaoAsync(new PericiasConducaoModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasCorporaisAsync(new PericiasCorporaisModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasEducacaoAsync(new PericiasEducacaoModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasPerformanceAsync(new PericiasPerformanceModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasSociaisAsync(new PericiasSociaisModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasTecnicasAsync(new PericiasTecnicasModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);
            await _personagemPericiaRepository.InsertPericiasLutaAsync(new PericiasLutaModel { IdPersonagem = idPersonagem, IdSessao = personagem.SessionId, Editavel = true }, ct);            

            await _personagemAtributoRepository.AddAsync(atributos, ct);            
        }

        public async Task AtualizarBriefing(int idPersonagem, string briefing, CancellationToken ct)
        {
            await _personagemRepository.AtualizarBriefingAsync(idPersonagem, briefing, ct);
            await _signalRService.AtualizarFicha(1, idPersonagem);
        }

        public async Task AtualizarRetrato(long idPersonagem, long idSessao, IFormFile portrait)
        {
            if (portrait == null || portrait.Length == 0)
                throw new Exception("Nenhuma imagem enviada.");

            var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };

            var extensao = Path.GetExtension(portrait.FileName).ToLowerInvariant();

            if (!extensoesPermitidas.Contains(extensao))
                throw new Exception("Formato de imagem não permitido.");

            var path = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var nomeArquivo = $"_potrait-{idPersonagem}_{idSessao}{extensao}";

            var caminhoArquivo = Path.Combine(path, nomeArquivo);

            foreach (var file in Directory.GetFiles(path, $"_potrait-{idPersonagem}_{idSessao}.*"))
            {
                File.Delete(file);
            }

            await using var stream = new FileStream(caminhoArquivo, FileMode.Create);
            await portrait.CopyToAsync(stream);
        }

        public async Task UpdateAtributos(PersonagemAtributosModel atributos, CancellationToken ct)
        {
            await _personagemAtributoRepository.UpdateAsync(atributos, ct);
            await _signalRService.AtualizarFicha(1, (int)atributos.IdPersonagem);
        }
    }
}
