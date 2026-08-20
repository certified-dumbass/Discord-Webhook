using System.Text.Json;
using Dreamstreaming.DiscordBot.Models;

namespace Dreamstreaming.DiscordBot.Services;

public class ScannerService
{
    private readonly JellyfinService _jellyfinService;
    private readonly string _lastScanFile;


    public ScannerService(
        JellyfinService jellyfinService,
        string lastScanFile)
    {
        _jellyfinService = jellyfinService;
        _lastScanFile = lastScanFile;
    }



    public async Task<ScanResult> Scan()
    {
        DateTime lastScan = LoadLastScan();


        var movies =
            await _jellyfinService.GetMovies();


        var series =
            await _jellyfinService.GetSeries();



        var result = new ScanResult
        {
            ScanDate = DateTime.Now
        };



        foreach(var movie in movies)
        {
            if(movie.DateAdded > lastScan)
            {
                result.NewMovies.Add(movie);
            }
        }



        foreach(var serie in series)
        {
            if(serie.DateAdded > lastScan)
            {
                result.NewSeries.Add(serie);
            }
        }



        SaveLastScan();


        return result;
    }



    private DateTime LoadLastScan()
    {
        if(!File.Exists(_lastScanFile))
        {
            return DateTime.MinValue;
        }


        string json =
            File.ReadAllText(_lastScanFile);


        using JsonDocument document =
            JsonDocument.Parse(json);


        return document.RootElement
            .GetProperty("LastScan")
            .GetDateTime();
    }




    private void SaveLastScan()
    {
        var data = new
        {
            LastScan = DateTime.Now
        };


        string json =
            JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });


        File.WriteAllText(
            _lastScanFile,
            json);
    }
}using System.Text.Json;
using Dreamstreaming.DiscordBot.Models;

namespace Dreamstreaming.DiscordBot.Services;

public class ScannerService
{
    private readonly JellyfinService _jellyfinService;
    private readonly string _lastScanFile;


    public ScannerService(
        JellyfinService jellyfinService,
        string lastScanFile)
    {
        _jellyfinService = jellyfinService;
        _lastScanFile = lastScanFile;
    }



    public async Task<ScanResult> Scan()
    {
        DateTime lastScan = LoadLastScan();


        var movies =
            await _jellyfinService.GetMovies();


        var series =
            await _jellyfinService.GetSeries();



        var result = new ScanResult
        {
            ScanDate = DateTime.Now
        };



        foreach(var movie in movies)
        {
            if(movie.DateAdded > lastScan)
            {
                result.NewMovies.Add(movie);
            }
        }



        foreach(var serie in series)
        {
            if(serie.DateAdded > lastScan)
            {
                result.NewSeries.Add(serie);
            }
        }



        SaveLastScan();


        return result;
    }



    private DateTime LoadLastScan()
    {
        if(!File.Exists(_lastScanFile))
        {
            return DateTime.MinValue;
        }


        string json =
            File.ReadAllText(_lastScanFile);


        using JsonDocument document =
            JsonDocument.Parse(json);


        return document.RootElement
            .GetProperty("LastScan")
            .GetDateTime();
    }




    private void SaveLastScan()
    {
        var data = new
        {
            LastScan = DateTime.Now
        };


        string json =
            JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });


        File.WriteAllText(
            _lastScanFile,
            json);
    }
}