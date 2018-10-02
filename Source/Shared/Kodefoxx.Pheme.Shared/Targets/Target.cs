using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;
using Microsoft.Extensions.Logging;

namespace Kodefoxx.Pheme.Shared.Targets
{
    /// <summary>
    /// Base implementation for a target.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message.</typeparam>
    public abstract class Target<TMessage, TTargetMessage> : ITarget<TMessage>
        where TMessage : IMessage
        where TTargetMessage : class
    {
        /// <summary>
        /// Holds a reference to the <see cref="ILogger{TCategoryName}"/> used.
        /// </summary>
        protected readonly ILogger<Target<TMessage, TTargetMessage>> _logger;

        /// <summary>
        /// Holds a reference to the <see cref="IMessageConverter{TMessage,TTargetMessage}"/> used.
        /// </summary>
        private readonly IMessageConverter<TMessage, TTargetMessage> _messageConverter;

        /// <summary>
        /// Creates a new <see cref="Target{TMessage,TTargetMessage}"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used.</param>
        /// <param name="messageConverter">The <see cref="IMessageConverter{TMessage,TTargetMessage}"/> used.</param>
        protected Target(ILogger<Target<TMessage, TTargetMessage>> logger, IMessageConverter<TMessage, TTargetMessage> messageConverter)
        {
            _logger = logger;
            _messageConverter = messageConverter;
        }

        /// <inheritdoc cref="ITarget{TMessage}"/>        
        public async Task PublishMessage(TMessage message)
        {
            _logger.LogDebug($"Starting publish of message '{message}'.");
            await PublishMessage(ConvertToTargetMessage(message));
            _logger.LogDebug($"Ended publish of message '{message}'.");       
        }

        /// <summary>
        /// Publishes the <typeparamref name="TTargetMessage"/>.
        /// </summary>
        /// <param name="targetMessage">The message to be published.</param>        
        protected abstract Task PublishMessage(TTargetMessage targetMessage);

        /// <summary>
        /// Converts a given <paramref name="message"/> to the type of a <typeparamref name="TTargetMessage"/>.
        /// </summary>
        /// <param name="message">The message to convert.</param>        
        private TTargetMessage ConvertToTargetMessage(TMessage message)
        {
            _logger.LogDebug($"Starting conversion from message type '{typeof(TMessage)}' to '{typeof(TTargetMessage)}' with '{_messageConverter.GetType()}'.");
            var convertedMessage = _messageConverter.ConvertToTargetMessage(message);
            _logger.LogDebug($"Message converted to '{typeof(TTargetMessage)}': '{convertedMessage}'.");
            _logger.LogDebug($"Ended conversion from message type '{typeof(TMessage)}' to '{typeof(TTargetMessage)}' with '{_messageConverter.GetType()}'.");
            return convertedMessage;
        }
    }
}
