using Kodefoxx.Pheme.Shared.Messages;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Converts a <see cref="Message"/> to a <see cref="SlackMessage"/>.
    /// </summary>
    public sealed class MessageToSlackMessageConverter : IMessageConverter<Message, SlackMessage>
    {        
        /// <inheritdoc cref="IMessageConverter{TMessage,TTargetMessage}"/>
        public SlackMessage ConvertToTargetMessage(Message message)
            => new SlackMessage
            {
                UserName = message.Author,
                Text = message.Content
            }
        ;
    }
}
