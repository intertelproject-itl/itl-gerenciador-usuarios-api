using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;

namespace itl_gerenciador_usuarios_api.Services.v1
{
    public class PersonagemService(IPersonagemRepository personagemRepository, IPersonagemAtributoRepository personagemAtributoRepository, IPersonagemPericiaRepository personagemPericiaRepository) : IPersonagemService
    {
        private readonly IPersonagemRepository _personagemRepository = personagemRepository;
        private readonly IPersonagemAtributoRepository _personagemAtributoRepository = personagemAtributoRepository;
        private readonly IPersonagemPericiaRepository _personagemPericiaRepository = personagemPericiaRepository;

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
            var pericias = new PersonagemPericiasModel
            {
                IdPersonagem = idPersonagem,
                Atletismo = 0,
                Briga = 0,
                Concentracao = 0,
                Conversa = 0,
                Educacao = 0,
                Evasao = 0,
                Intimidacao = 0,
                Percepcao = 0,
                Persuasao = 0,
                Pilotagem = 0,
                PrimeirosSocorros = 0,
                Furtividade = 0,
                Sobrevivencia = 0,
                Negociacao = 0,
                Criminologia = 0,
                Deducao = 0,
                ResistirDrogasTortura = 0,
                TecnologiaBasica = 0,
                SegurancaEletronica = 0,
                Hackear = 0,
                MecanicaTerrestre = 0,
                Medicina = 0,
                Ciencia = 0,
                ArmasDeFogo = 0,
                ArmasPesadas = 0,
                LutaCorpoACorpo = 0,
                Editavel = 1
            };

            await _personagemAtributoRepository.AddAsync(atributos, ct);
            await _personagemPericiaRepository.AddAsync(pericias, ct);
        }        

        public async Task UpdateAtributos(PersonagemAtributosModel atributos, CancellationToken ct)
        {
            await _personagemAtributoRepository.UpdateAsync(atributos, ct);
        }

        public async Task UpdatePericias(PersonagemPericiasModel pericias, CancellationToken ct)
        {
            await _personagemPericiaRepository.UpdateAsync(pericias, ct);
        }
    }
}
