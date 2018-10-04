using System.Collections.Generic;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Holds options for use in the <see cref="TeamsWebHookClient"/>.
    /// </summary>
    public sealed class TeamsWebHookClientOptions
    {
        /// <summary>
        /// Gets the available web hooks.
        /// </summary>
        public IEnumerable<TeamsWebHookUrl> WebHookUrls { get; set; }
    }
    
    /// <summary>
    /// Gets a configuration for a single url.
    /// </summary>
    public sealed class TeamsWebHookUrl
    {
        /// <summary>
        /// The actual web hook url
        /// </summary>
        public string Url { get; set; }        
    }
}
