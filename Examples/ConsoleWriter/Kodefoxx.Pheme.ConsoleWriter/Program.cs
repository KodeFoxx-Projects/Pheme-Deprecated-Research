using Kodefoxx.Pheme.ConsoleWriter.Infrastructure.ServiceCollection;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Kodefoxx.Pheme.Slack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kodefoxx.Pheme.Teams;
using Microsoft.Extensions.Configuration;

namespace Kodefoxx.Pheme.ConsoleWriter
{
    class Program
    {
        /// <summary>
        /// Bootstrapping / Entry point for the application.        
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()                    
                .SetBasePath(Directory.GetCurrentDirectory())
                .ConfigureSlackWebHookClientOptions()
                .ConfigureTeamsWebHookClientOptions()
                .Build()
            ;

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var serviceProvider = serviceCollection
                .AddSingleton<Program>()                
                .BuildServiceProvider()
            ;

            var program = serviceProvider.GetService<Program>();
            program.Run();
        }

        /// <summary>
        /// Configure services.
        /// </summary>        
        private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .AddAndConfigureLogging()
                .AddAndConfigureSlackWebHookTarget(() => new MessageToSlackMessageConverter(), configuration)
                .AddAndConfigureTeamsWebHookTarget(() => new MessageToTeamsMessageConverter(), configuration)
        ;

        /// <summary>
        /// Holds a reference to the logger instance.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The <see cref="ITarget{TMessage}"/>s.
        /// </summary>
        private readonly IEnumerable<ITarget<Message>> _targets;        

        /// <summary>
        /// Creates a new <see cref="Program"/> instance.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="targets">The target to use.</param>
        public Program(ILogger<Program> logger, IEnumerable<ITarget<Message>> targets)
        {
            _logger = logger;
            _targets = targets;
        }

        /// <summary>
        /// Runs the example.
        /// </summary>
        public void Run()
        {
            var message = new Message
            {
                Author = "Kodefoxx",
                Content = "Hello, world!\n ~ from https://github.com/KodeFoxx-Projects/Pheme"
            };

            _targets.ToList().ForEach(async target 
                => await target.PublishMessage(message)
            );
        }
    }
}
