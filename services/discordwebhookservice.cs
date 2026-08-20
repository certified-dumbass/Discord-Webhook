using System.Net.Http.Json;
using Dreamstreaming.DiscordBot.Models;

namespace Dreamstreaming.DiscordBot.Services;


public class DiscordWebhookService
{
    private readonly string _webhookUrl;

    private readonly HttpClient _client;



    public DiscordWebhookService(string webhookUrl)
    {
        _webhookUrl = webhookUrl;

        _client = new HttpClient();
    }



    public async Task SendScanResult(ScanResult result)
    {

        string message =
            CreateMessage(result);



        await _client.PostAsJsonAsync(
            _webhookUrl,
            new
            {
                content = message
            });
    }




    private string CreateMessage(
        ScanResult result)
    {

        string message =
            "💜 **Dreamstreaming Weekly Update**\n\n";



        message += "🎬 **Movies**\n";


        if(result.NewMovies.Count == 0)
        {
            message += "Geen nieuwe films\n";
        }
        else
        {
            foreach(var movie in result.NewMovies)
            {
                message +=
                    $"🍿 {movie.Name} ({movie.Year})\n";
            }
        }



        message += "\n📺 **Series**\n";


        if(result.NewSeries.Count == 0)
        {
            message += "Geen nieuwe series\n";
        }
        else
        {
            foreach(var serie in result.NewSeries)
            {
                message +=
                    $"📺 {serie.Name} ({serie.Year})\n";
            }
        }



        message +=
            "\n🌙 Veel kijkplezier op Dreamstreaming!";


        return message;
    }
}