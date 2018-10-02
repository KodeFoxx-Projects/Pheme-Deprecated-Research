using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Target that publishes to slack.
    /// </summary>
    public sealed class MessageToSlackMessageTarget : Target<Message, SlackMessage>
    {
        /// <summary>
        /// Holds a reference to the <see cref="SlackWebHookClient"/> being used.
        /// </summary>
        private readonly SlackWebHookClient _slackWebHookClient;

        /// <summary>
        /// Holds a reference to the <see cref="SlackWebHookClientOptions"/> being used.
        /// </summary>
        private readonly SlackWebHookClientOptions _slackWebHookClientOptions;

        /// <summary>
        /// Creates a new <see cref="MessageToSlackMessageTarget"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used.</param>
        /// <param name="messageConverter">The <see cref="IMessageConverter{TMessage,TTargetMessage}"/> used.</param>
        /// <param name="slackWebHookClient">The <see cref="SlackWebHookClient"/> used to communicate with slack.</param>
        /// <param name="slackWebHookClientOptions">The options used.</param>
        public MessageToSlackMessageTarget(
            ILogger<Target<Message, SlackMessage>> logger, IMessageConverter<Message, SlackMessage> messageConverter,
            SlackWebHookClient slackWebHookClient, IOptions<SlackWebHookClientOptions> slackWebHookClientOptions
        ) : base(logger, messageConverter)
        {
            _slackWebHookClient = slackWebHookClient;
            _slackWebHookClientOptions = slackWebHookClientOptions.Value;
        }
        
        /// <inheritdoc cref="Target{TMessage,TTargetMessage}"/>                
        protected override async Task PublishMessage(SlackMessage targetMessage)
        {
            _logger.LogInformation($"Publishing message '{targetMessage}'...");
            foreach (var webHookUrl in _slackWebHookClientOptions.WebHookUrls)
            {
                targetMessage.Channel = webHookUrl.Channel;
                targetMessage.IconUrl = _slackWebHookClientOptions.IconUrl;
                targetMessage.UserName = _slackWebHookClientOptions.AppName;
                await _slackWebHookClient.Publish(webHookUrl.Url, JsonConvert.SerializeObject(targetMessage));
            }            
            _logger.LogInformation($"Published message '{targetMessage}'.");            
        }
    }
}