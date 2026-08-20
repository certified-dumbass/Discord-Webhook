using MediaBrowser.Common.Plugins;
using MediaBrowser.Controller;
using MediaBrowser.Model.Plugins;
using Dreamstreaming.DiscordBot.Configuration;

namespace Dreamstreaming.DiscordBot;

public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    public Plugin(
        IApplicationPaths applicationPaths,
        IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
    }

    public override string Name => "Dreamstreaming Discord Bot";

    public override Guid Id =>
        Guid.Parse("7B7E6E2A-5F2B-4A3D-9F64-9D0E3C6D8A21");

    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            Name = "Dreamstreaming Discord Bot",
            EmbeddedResourcePath =
                $"{GetType().Namespace}.Web.config.html"
        };
    }
}