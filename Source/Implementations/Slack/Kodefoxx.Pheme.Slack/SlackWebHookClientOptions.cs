using System.Collections.Generic;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Holds options for use in the <see cref="SlackWebHookClient"/>.
    /// </summary>
    public sealed class SlackWebHookClientOptions
    {
        /// <summary>
        /// Gets the available web hooks.
        /// </summary>
        public IEnumerable<SlackWebHookUrl> WebHookUrls { get; set; }

        /// <summary>
        /// Holds a reference to an icon url for the app.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets/sets the app name.
        /// </summary>
        public string AppName { get; set; }
    }

    /// <summary>
    /// Gets a configuration for a single url.
    /// </summary>
    public sealed class SlackWebHookUrl
    {        
        /// <summary>
        /// The actual web hook url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The channel to post to.
        /// </summary>
        public string Channel { get; set; }
    }
}
