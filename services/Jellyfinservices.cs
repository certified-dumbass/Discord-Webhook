using System.Net.Http.Headers;
using System.Text.Json;
using Dreamstreaming.DiscordBot.Configuration;
using Dreamstreaming.DiscordBot.Models;

namespace Dreamstreaming.DiscordBot.Services;

public class JellyfinService
{
    private readonly string _jellyfinUrl;
    private readonly string _apiKey;

    private readonly HttpClient _client;


    public JellyfinService(PluginConfiguration configuration)
    {
        _jellyfinUrl = configuration.JellyfinUrl.TrimEnd('/');
        _apiKey = configuration.JellyfinApiKey;

        _client = new HttpClient();

        _client.DefaultRequestHeaders.Add(
            "X-Emby-Token",
            _apiKey
        );
    }


    public async Task<List<Movie>> GetMovies()
    {
        var movies = new List<Movie>();

        string url =
            $"{_jellyfinUrl}/Items?Recursive=true&IncludeItemTypes=Movie";

        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string json =
            await response.Content.ReadAsStringAsync();

        using JsonDocument document =
            JsonDocument.Parse(json);

        foreach (var item in document
            .RootElement
            .GetProperty("Items")
            .EnumerateArray())
        {
            movies.Add(new Movie
            {
                Id =
                    item.GetProperty("Id")
                    .GetString(),

                Name =
                    item.GetProperty("Name")
                    .GetString(),

                DateAdded =
                    item.GetProperty("DateCreated")
                    .GetDateTime(),

                Year =
                    item.TryGetProperty(
                        "ProductionYear",
                        out var year)
                        ? year.GetInt32()
                        : null
            });
        }

        return movies;
    }


    public async Task<List<Series>> GetSeries()
    {
        var series = new List<Series>();

        string url =
            $"{_jellyfinUrl}/Items?Recursive=true&IncludeItemTypes=Series";

        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string json =
            await response.Content.ReadAsStringAsync();

        using JsonDocument document =
            JsonDocument.Parse(json);

        foreach (var item in document
            .RootElement
            .GetProperty("Items")
            .EnumerateArray())
        {
            series.Add(new Series
            {
                Id =
                    item.GetProperty("Id")
                    .GetString(),

                Name =
                    item.GetProperty("Name")
                    .GetString(),

                DateAdded =
                    item.GetProperty("DateCreated")
                    .GetDateTime(),

                Year =
                    item.TryGetProperty(
                        "ProductionYear",
                        out var year)
                        ? year.GetInt32()
                        : null
            });
        }

        return series;
    }
}