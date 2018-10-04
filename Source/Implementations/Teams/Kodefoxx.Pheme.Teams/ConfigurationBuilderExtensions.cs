using Microsoft.Extensions.Configuration;

namespace Kodefoxx.Pheme.Teams
{
    /// <summary>
    /// Holds extensions for use on <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Configures to loads <see cref="TeamsWebHookClientOptions"/> form user secrets.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="ConfigurationBuilder"/> to use.</param>        
        public static IConfigurationBuilder ConfigureTeamsWebHookClientOptions(
            this IConfigurationBuilder configurationBuilder)
            => configurationBuilder
                .AddUserSecrets<TeamsWebHookClientOptions>()
        ;

        /***** USER SECRETS ********************************************************************
         * 1. Stored in "%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json"
         * 2. Generate your own via cli command "dotnet user-secrets set YourSecretName "YourSecretContent""                 
         * More info on https://stackoverflow.com/a/48666491/1155847
        ***************************************************************************************/
        /***** TeamsWebHookClientOptions json format ******************************************
        "TeamsWebHookClientOptions": {    
          "WebHookUrls": [
            {
              "Url": "https://outlook.office.com/webhook/7ca336bb-c2f8-4672-8c81-2d5f94702683@ed1fc57f-8a97-47e7-9de1-9302dfd786ae/IncomingWebhook/935b81e22d7a4ce4819911e74abcf27a/1a14e4af-6260-4bd9-ab6b-62480cd31b19"       
            }
          ]
        }
        ***************************************************************************************/
    }
}
