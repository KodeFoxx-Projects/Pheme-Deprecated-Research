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
        public IEnumerable<string> WebHookUrls { get; set; }        
    }
}
