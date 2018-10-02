using Kodefoxx.Pheme.ConsoleWriter.Infrastructure.ServiceCollection;
using Kodefoxx.Pheme.Shared.Messages;
using Kodefoxx.Pheme.Shared.Targets;
using Kodefoxx.Pheme.Slack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using ILogger = Microsoft.Extensions.Logging.ILogger;

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
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
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
        private static void ConfigureServices(ServiceCollection serviceCollection)
            => serviceCollection
                .AddAndConfigureLogging()
                .AddAndConfigureSlackTarget(() => new MessageToSlackMessageConverter())
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
                Content = "Hello, world!"
            };

            _targets.ToList().ForEach(target 
                => target.PublishMessage(message)
            );
        }
    }
}
