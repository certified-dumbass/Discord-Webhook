namespace Dreamstreaming.DiscordBot.Models;

public class ScanResult
{
    public DateTime ScanDate { get; set; }

    public List<Movie> NewMovies { get; set; }

    public List<Series> NewSeries { get; set; }


    public ScanResult()
    {
        NewMovies = new List<Movie>();
        NewSeries = new List<Series>();
    }
}