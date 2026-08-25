using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dreamstreaming.DiscordBot.Services;

namespace Dreamstreaming.DiscordBot.Controllers;

[ApiController]
[Route("Dreamstreaming/DiscordBot")]
[Authorize(Policy = "RequiresElevation")]
public class DiscordBotController : ControllerBase
{
    private readonly Plugin _plugin;

    public DiscordBotController(Plugin plugin)
    {
        _plugin = plugin;
    }

    [HttpPost("TestDiscord")]
    public async Task<ActionResult> TestDiscord()
    {
        var configuration = _plugin.Configuration;

        if (string.IsNullOrWhiteSpace(configuration.DiscordWebhook))
        {
            return BadRequest(new
            {
                Success = false,
                Message = "Discord webhook is niet ingesteld."
            });
        }

        try
        {
            using var discordService =
                new DiscordWebhookService(
                    configuration.DiscordWebhook);

            await discordService.SendTestMessage();

            return Ok(new
            {
                Success = true,
                Message =
                    "Discord webhook test succesvol verzonden."
            });
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new
            {
                Success = false,
                Message =
                    $"Discord weigerde de webhook request: {ex.Message}"
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                Success = false,
                Message =
                    $"Ongeldige Discord webhook: {ex.Message}"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                Success = false,
                Message =
                    $"Onverwachte fout tijdens Discord test: {ex.Message}"
            });
        }
    }
}