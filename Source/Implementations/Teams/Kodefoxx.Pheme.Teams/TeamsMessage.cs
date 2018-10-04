using System.Diagnostics;
using Newtonsoft.Json;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Represents a slack message.
    /// </summary>
    [DebuggerDisplay("Text: \"{Text}\"")]
    public sealed class TeamsMessage
    {
        /// <summary>
        /// Represents the message context.
        /// </summary>
        [JsonProperty("@context")]
        public string Context 
            => "https://schema.org.extensions"
        ;

        /// <summary>
        /// Represents the type of "card"/message.
        /// </summary>
        [JsonProperty("@type")]
        public string Type
            => "MessageCard"
        ;

        /// <summary>
        /// Represents the text published.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }        

        /// <inheritdoc cref="object.ToString"/>        
        public override string ToString()
            => $"Text: \"{Text}\""
        ;
    }
}
