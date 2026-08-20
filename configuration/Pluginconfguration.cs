using MediaBrowser.Model.Plugins;

namespace Dreamstreaming.DiscordBot.Configuration;

public class PluginConfiguration : BasePluginConfiguration
{
    public string JellyfinUrl { get; set; } = string.Empty;

    public string JellyfinApiKey { get; set; } = string.Empty;

    public string DiscordWebhook { get; set; } = string.Empty;

    public int ScanIntervalHours { get; set; } = 168;
}