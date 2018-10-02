using System.Diagnostics;
using Newtonsoft.Json;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Represents a slack message.
    /// </summary>
    [DebuggerDisplay("UserName: \"{UserName}\" | Text: \"{Text}\" | Channel: \"{Channel}\"")]
    public sealed class SlackMessage
    {
        /// <summary>
        /// Represents the username the message will be posted under.
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Represents the text published.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Represents the channel to publish to.
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Sets the icon url for the app.
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <inheritdoc cref="object.ToString"/>        
        public override string ToString()
            => $"UserName: \"{UserName}\" | Text: \"{Text}\" | Channel: \"{Channel}\""
        ;
    }
}
