using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Repositories.v1;
using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController(IPersonagemService personagemService) : ControllerBase
    {

        private readonly IPersonagemService _personagemService = personagemService;

        [HttpPost]
        public async Task<ActionResult> RegistrarPersonagem(PersonagemRequestDTO personagemDto)
        {
            try
            {
                await _personagemService.RegistrarPersonagem(personagemDto, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("retrato/{idPersonagem}/{idSessao}")]
        public async Task<ActionResult> AtualizarRestrato([FromRoute] long idPersonagem, long idSessao, IFormFile portrait)
        {
            try
            {
                await _personagemService.AtualizarRetrato(idPersonagem, idSessao, portrait);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("atributos")]
        public async Task<ActionResult> UpdateAtributos([FromBody] PersonagemAtributosModel atributos)
        {
            try
            {
                await _personagemService.UpdateAtributos(atributos, new CancellationToken());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("pericias")]
        public async Task<ActionResult> UpdatePericias([FromBody] PersonagemPericiasModel pericias)
        {
            try
            {
                await _personagemService.UpdatePericias(pericias, new CancellationToken());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}