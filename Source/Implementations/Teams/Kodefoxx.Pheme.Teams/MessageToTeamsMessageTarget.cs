using System.Threading.Tasks;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Target that publishes to teams.
    /// </summary>
    public sealed class MessageToTeamsMessageTarget : Target<Message, TeamsMessage>
    {
        /// <summary>
        /// Holds a reference to the <see cref="TeamsWebHookClient"/> being used.
        /// </summary>
        private readonly TeamsWebHookClient _teamsWebHookClient;

        /// <summary>
        /// Holds a reference to the <see cref="TeamsWebHookClientOptions"/> being used.
        /// </summary>
        private readonly TeamsWebHookClientOptions _teamsWebHookClientOptions;

        /// <summary>
        /// Creates a new <see cref="MessageToTeamsMessageTarget"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used.</param>
        /// <param name="messageConverter">The <see cref="IMessageConverter{TMessage,TTargetMessage}"/> used.</param>
        /// <param name="teamsWebHookClient">The <see cref="TeamsWebHookClient"/> used to communicate with slack.</param>
        /// <param name="teamsWebHookClientOptions">The options used.</param>

        public MessageToTeamsMessageTarget(
            ILogger<Target<Message, TeamsMessage>> logger, IMessageConverter<Message, TeamsMessage> messageConverter,
            TeamsWebHookClient teamsWebHookClient, IOptions<TeamsWebHookClientOptions> teamsWebHookClientOptions
        ) : base(logger, messageConverter)
        {
            _teamsWebHookClient = teamsWebHookClient;
            _teamsWebHookClientOptions = teamsWebHookClientOptions.Value;
        }

        /// <inheritdoc cref="Target{TMessage,TTargetMessage}"/> 
        protected override async Task PublishMessage(TeamsMessage targetMessage)
        {
            _logger.LogInformation($"Publishing message '{targetMessage}'...");
            foreach (var webHookUrl in _teamsWebHookClientOptions.WebHookUrls)
            {
                await _teamsWebHookClient.Publish(webHookUrl.Url, JsonConvert.SerializeObject(targetMessage));
            }
            _logger.LogInformation($"Published message '{targetMessage}'.");
        }
    }
}
