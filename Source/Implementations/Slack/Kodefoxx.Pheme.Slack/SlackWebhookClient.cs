using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// The implementation for communication to slack via a webhook.
    /// For more info, see: https://api.slack.com/incoming-webhooks.
    /// </summary>
    public sealed class SlackWebHookClient
    {
        /// <summary>
        /// Holds a reference to the <see cref="ILogger{TCategoryName}"/> used.
        /// </summary>
        private readonly ILogger<SlackWebHookClient> _logger;

        /// <summary>
        /// Creates a new <see cref="SlackWebHookClient"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used.</param>        
        public SlackWebHookClient(ILogger<SlackWebHookClient> logger)
            => _logger = logger
        ;

        /// <summary>
        /// Publishes a <paramref name="slackJsonMessage"/> to a given <paramref name="channel"/> on slack.
        /// </summary>
        /// <param name="webHookUrl">Unique slack web hook url for your workspace and channel</param>        
        /// <param name="slackJsonMessage">The message (in slack's json format). More info on the format, see "https://api.slack.com/incoming-webhooks".</param>        
        public Task Publish(string webHookUrl, string slackJsonMessage)
        {
            _logger.LogDebug($"Start publishing via WebHook '{webHookUrl}', with content '{slackJsonMessage}'.");
            using (WebClient webClient = new WebClient())
            {
                var data = new NameValueCollection();
                data["payload"] = slackJsonMessage;

                _logger.LogDebug("Starting to upload named values...");
                try
                {
                    var response = webClient.UploadValues(new Uri(webHookUrl), "POST", data);
                    var responseText = new UTF8Encoding().GetString(response);
                    _logger.LogDebug($"Uploaded named values, response text was: '{responseText}'.");
                    _logger.LogDebug($"End publishing via WebHook '{webHookUrl}', with content '{slackJsonMessage}'.");
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Could not upload name values due to '{ex.GetType()}': '{ex.Message}'.");
                    throw;
                }

            }                       
        }
    }
}
