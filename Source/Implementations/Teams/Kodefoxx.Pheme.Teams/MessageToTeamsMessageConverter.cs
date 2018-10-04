using Kodefoxx.Pheme.Shared.Messages;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Converts a <see cref="Message"/> to a <see cref="TeamsMessage"/>.
    /// </summary>
    public sealed class MessageToTeamsMessageConverter : IMessageConverter<Message, TeamsMessage>
    {
        /// <inheritdoc cref="IMessageConverter{TMessage,TTargetMessage}"/>
        public TeamsMessage ConvertToTargetMessage(Message message)
            => new TeamsMessage
            {
                Text = message.Content
            }
        ;
    }
}
