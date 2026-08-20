using System.Text.Json;
using Dreamstreaming.DiscordBot.Services;


Console.WriteLine("🎬 Dreamstreaming Discord Bot gestart!");
Console.WriteLine("------------------------------------");



// Config laden

var configJson =
    File.ReadAllText("config.json");


var config =
    JsonSerializer.Deserialize<JsonElement>(configJson);



string jellyfinUrl =
    config
    .GetProperty("Jellyfin")
    .GetProperty("Url")
    .GetString();



string apiKey =
    config
    .GetProperty("Jellyfin")
    .GetProperty("ApiKey")
    .GetString();



Console.WriteLine("✅ Config geladen");



// Jellyfin service starten

var jellyfinService =
    new JellyfinService(
        jellyfinUrl,
        apiKey
    );


Console.WriteLine("✅ Verbonden met Jellyfin service");



// Scanner starten

var scanner =
    new ScannerService(
        jellyfinService,
        "Data/lastscan.json"
    );


Console.WriteLine("🔎 Server scan gestart...");



var result =
    await scanner.Scan();



Console.WriteLine();
Console.WriteLine("===== NIEUWE TOEVOEGINGEN =====");



// Films tonen

Console.WriteLine();
Console.WriteLine("🎬 MOVIES:");

foreach(var movie in result.NewMovies)
{
    Console.WriteLine(
        $"- {movie.Name} ({movie.Year})"
    );
}



// Series tonen

Console.WriteLine();
Console.WriteLine("📺 SERIES:");

foreach(var serie in result.NewSeries)
{
    Console.WriteLine(
        $"- {serie.Name} ({serie.Year})"
    );
}



Console.WriteLine();
Console.WriteLine("------------------------------------");
Console.WriteLine("✅ Scan voltooid!");