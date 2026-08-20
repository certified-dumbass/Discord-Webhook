using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
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

    public override string Name =>
        "Dreamstreaming Discord Bot";

    public override Guid Id =>
        Guid.Parse("7B7E6E2A-5F2B-4A3D-9F64-9D0E3C6D8A21");

    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            Name = "DreamstreamingDiscordBotConfiguration",

            DisplayName = "Dreamstreaming Discord Bot",

            EmbeddedResourcePath =
                $"{GetType().Namespace}.Web.config.html"
        };
    }
}