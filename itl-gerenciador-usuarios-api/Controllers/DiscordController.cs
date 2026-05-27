using itl_gerenciador_usuarios_api.Domain.Dto;
using itl_gerenciador_usuarios_api.Domain.Interface.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace itl_gerenciador_usuarios_api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DiscordController(IDiscordIntegration discordIntegration) : ControllerBase
    {
        private readonly IDiscordIntegration _discord = discordIntegration;

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] DiscordMessageDTO dto)
        {
            try
            {
                await _discord.SendMessageAsync(dto, new CancellationToken());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
