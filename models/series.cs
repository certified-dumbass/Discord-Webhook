namespace Dreamstreaming.DiscordBot.Models;

public class Series
{
    public string Name { get; set; }

    public string Id { get; set; }

    public DateTime DateAdded { get; set; }

    public string PosterUrl { get; set; }

    public int? Year { get; set; }

    public int? Seasons { get; set; }

    public int? Episodes { get; set; }
}