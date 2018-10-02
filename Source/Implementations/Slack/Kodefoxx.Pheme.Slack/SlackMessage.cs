using System.Diagnostics;
using Newtonsoft.Json;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Represents a slack message.
    /// </summary>
    [DebuggerDisplay("UserName: \"{UserName}\" | Text: \"{Text}\"")]
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

        /// <inheritdoc cref="object.ToString"/>        
        public override string ToString()
            => $"UserName: \"{UserName}\" | Text: \"{Text}\""
        ;
    }
}
