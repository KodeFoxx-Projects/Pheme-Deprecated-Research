using System;
using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Microsoft.Extensions.Logging;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Target that publishes to slack.
    /// </summary>
    public sealed class SlackTarget : ITarget<Message>
    {
        /// <summary>
        /// Holds a reference to the logger being used.
        /// </summary>
        private readonly ILogger<SlackTarget> _logger;

        /// <summary>
        /// Holds a reference to the message converter.
        /// </summary>
        private readonly IMessageConverter<Message, SlackMessage> _messageConverter;

        /// <summary>
        /// Creates a new <see cref="SlackTarget"/> instance.
        /// </summary>
        /// <param name="messageConverter">The message converter to use.</param>
        public SlackTarget(ILogger<SlackTarget> logger, IMessageConverter<Message, SlackMessage> messageConverter)
        {
            _logger = logger;
            _messageConverter = messageConverter;
        }

        /// <inheritdoc cref="ITarget{TMessage}"/>        
        public Task PublishMessage(Message message)
        {
            _logger.LogInformation($"Trying to publish message '{message}'.");
            var slackMessage = _messageConverter.ConvertToTargetMessage(message);
            _logger.LogInformation($"Published message '{message}'.");
            return Task.CompletedTask;
        }        
    }
}
