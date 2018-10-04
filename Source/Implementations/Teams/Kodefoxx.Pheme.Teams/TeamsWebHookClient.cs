using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// The implementation for communication to teams via a web hook.
    /// For more info, see: https://docs.microsoft.com/en-us/outlook/actionable-messages/actionable-messages-via-connectors.
    /// </summary>
    public sealed class TeamsWebHookClient
    {
        /// <summary>
        /// Holds a reference to the <see cref="ILogger{TCategoryName}"/> used.
        /// </summary>
        private readonly ILogger<TeamsWebHookClient> _logger;

        /// <summary>
        /// Creates a new <see cref="TeamsWebHookClient"/> instance.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used.</param>        
        public TeamsWebHookClient(ILogger<TeamsWebHookClient> logger)
            => _logger = logger
        ;

        /// <summary>
        /// Publishes a <paramref name="teamsJsonMessage"/> to a given <paramref name="channel"/> on slack.
        /// </summary>
        /// <param name="webHookUrl">Unique slack web hook url for your workspace and channel</param>        
        /// <param name="teamsJsonMessage">The message (in slack's json format). More info on the format, see "https://docs.microsoft.com/en-us/outlook/actionable-messages/actionable-messages-via-connectors".</param>        
        public Task Publish(string webHookUrl, string teamsJsonMessage)
        {
            _logger.LogDebug($"Start publishing via WebHook '{webHookUrl}', with content '{teamsJsonMessage}'.");
            using (WebClient webClient = new WebClient())
            {
                _logger.LogDebug("Starting to upload json string...");
                try
                {
                    var responseText = webClient.UploadString(new Uri(webHookUrl), "POST", teamsJsonMessage);                    
                    _logger.LogDebug($"Uploaded json string, response text was: '{responseText}'.");
                    _logger.LogDebug($"End publishing via WebHook '{webHookUrl}', with content '{teamsJsonMessage}'.");
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Could not upload json string due to '{ex.GetType()}': '{ex.Message}'.");
                    throw;
                }

            }
        }
    }
}
