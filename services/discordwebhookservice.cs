using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Dreamstreaming.DiscordBot.Models;

namespace Dreamstreaming.DiscordBot.Services;

public class DiscordWebhookService : IDisposable
{
    private readonly string _webhookUrl;
    private readonly HttpClient _client;

    public DiscordWebhookService(string webhookUrl)
    {
        if (string.IsNullOrWhiteSpace(webhookUrl))
        {
            throw new ArgumentException(
                "Discord webhook URL cannot be empty.",
                nameof(webhookUrl));
        }

        if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out var uri))
        {
            throw new ArgumentException(
                "Discord webhook URL is invalid.",
                nameof(webhookUrl));
        }

        if (uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException(
                "Discord webhook URL must use HTTPS.",
                nameof(webhookUrl));
        }

        _webhookUrl = webhookUrl.Trim();
        _client = new HttpClient();
    }

    public async Task SendScanResult(ScanResult result)
    {
        string message = CreateMessage(result);

        using var response = await _client.PostAsJsonAsync(
            _webhookUrl,
            new
            {
                content = message
            });

        response.EnsureSuccessStatusCode();
    }

    public async Task SendTestMessage()
    {
        using var response = await _client.PostAsJsonAsync(
            _webhookUrl,
            new
            {
                content =
                    "💜 **Dreamstreaming Discord Bot**\n\n" +
                    "✅ Testbericht succesvol verzonden!"
            });

        response.EnsureSuccessStatusCode();
    }

    private string CreateMessage(ScanResult result)
    {
        string message =
            "💜 **Dreamstreaming Weekly Update**\n\n";

        message += "🎬 **Movies**\n";

        if (result.NewMovies.Count == 0)
        {
            message += "Geen nieuwe films\n";
        }
        else
        {
            foreach (var movie in result.NewMovies)
            {
                message +=
                    $"🍿 {movie.Name} ({movie.Year})\n";
            }
        }

        message += "\n📺 **Series**\n";

        if (result.NewSeries.Count == 0)
        {
            message += "Geen nieuwe series\n";
        }
        else
        {
            foreach (var serie in result.NewSeries)
            {
                message +=
                    $"📺 {serie.Name} ({serie.Year})\n";
            }
        }

        message +=
            "\n🌙 Veel kijkplezier op Dreamstreaming!";

        return message;
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}