namespace Dreamstreaming.DiscordBot.Models;

public class Movie
{
    public string Name { get; set; }

    public int? Year { get; set; }

    public string Id { get; set; }

    public DateTime DateAdded { get; set; }

    public string PosterUrl { get; set; }
}