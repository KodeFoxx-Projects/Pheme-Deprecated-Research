**Configuration**
1. See demo-app at https://github.com/KodeFoxx-Projects/Pheme/blob/master/Examples/ConsoleWriter/Kodefoxx.Pheme.ConsoleWriter/Program.cs where following extensions are used:

*1.1 .ConfigureSlackWebHookClientOptions()* makes sure that `SlackWebHookClientOptions` are loaded from UserSecrets.
```
var configuration = new ConfigurationBuilder()                    
   .SetBasePath(Directory.GetCurrentDirectory())
   .ConfigureSlackWebHookClientOptions()                
   .Build()
;
```
*1.2 .AddAndConfigureSlackWebHookTarget()* registers all the necessary classes/implementations into the DI service container. Currently the demo app uses a standard `Message` - but it's recommended you adapt this to suit your own application's needs.
```
private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    => serviceCollection
        .AddAndConfigureLogging()
        .AddAndConfigureSlackWebHookTarget(() => new MessageToSlackMessageConverter(), configuration)
    ;
```

2. Use UserSecrets to configure and then make sure to add the following structure into `secrets.json`:
```
{
  "SlackWebHookClientOptions": {
    "AppName": "Kodefoxx",
    "IconUrl": "url-to-a-jpeg-or-png",
    "WebHookUrls": [
      {
        "Url": "xxxxxxxxxxxxx",
        "Channel": "general"
      },
      {
        "Url": "xxxxxxxxxxxx",
        "Channel": "test-channel"
      }
    ]
  }
}
```
