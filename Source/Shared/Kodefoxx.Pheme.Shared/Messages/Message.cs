using System.Diagnostics;

namespace Kodefoxx.Pheme.Shared.Messages
{
    /// <summary>
    /// Represents a basic message.
    /// </summary>
    [DebuggerDisplay("Author: \"{Author}\" | Content: \"{Content}\"")]
    public sealed class Message : IMessage
    {
        /// <summary>
        /// The author of the message.
        /// </summary>
        public string Author { get; set; }

        /// <summary>        
        /// The content of the message.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc cref="object.ToString"/>        
        public override string ToString()
            => $"Author: \"{Author}\" | Content: \"{Content}\""
        ;
    }
}
