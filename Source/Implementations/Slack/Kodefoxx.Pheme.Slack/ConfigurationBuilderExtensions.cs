using Microsoft.Extensions.Configuration;

namespace Kodefoxx.Pheme.Slack
{
    /// <summary>
    /// Holds extensions for use on <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Configures to loads <see cref="SlackWebHookClientOptions"/> form user secrets.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="ConfigurationBuilder"/> to use.</param>        
        public static IConfigurationBuilder ConfigureSlackWebHookClientOptions(
            this IConfigurationBuilder configurationBuilder)
            => configurationBuilder
                .AddUserSecrets<SlackWebHookClientOptions>()
        ;

        /***** USER SECRETS ********************************************************************
         * 1. Stored in "%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json"
         * 2. Generate your own via cli command "dotnet user-secrets set YourSecretName "YourSecretContent""                 
         * More info on https://stackoverflow.com/a/48666491/1155847
        ***************************************************************************************/
        /***** SlackWebHookClientOptions json format ******************************************
        {
          "SlackWebHookClientOptions": {
            "AppName": "Kodefoxx",
            "IconUrl": "https://avatars2.githubusercontent.com/u/33200491?s=400&u=feb9832532ac4329a3814acb5919e646ecf92619&v=4",
            "WebHookUrls": [
              {
                "Url": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "Channel": "pheme-test-channel"
              },
              {
                "Url": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "Channel": "random"
              }
            ]
          }
        }
        ***************************************************************************************/
    }
}
